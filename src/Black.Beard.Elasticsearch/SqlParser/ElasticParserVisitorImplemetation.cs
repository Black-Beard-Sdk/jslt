using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.Elastic.Runtimes;
using Bb.Elastic.SqlParser.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bb.Elastic.Parser
{

    public class ElasticParserVisitorImplemetation : ElasticParserBaseVisitor<AstBase>
    {

        public ElasticParserVisitorImplemetation(ContextExecutor ctx)
        {
            this._ctx = ctx;
            this._currentCulture = ctx.Culture ?? CultureInfo.InvariantCulture;
        }

        public override AstBase Visit(IParseTree tree)
        {

            EvaluateErrors(tree);
            if (this._ctx.Trace.InError)
                Stop();
            return base.Visit(tree);

        }

        public override AstBase VisitSql_stmt_list([NotNull] ElasticParser.Sql_stmt_listContext context)
        {

            AstList<AstBase> result = new AstList<AstBase>(GetLocator(context));
            var stmts = context.sql_stmt();

            foreach (var item in stmts)
            {
                var a = item.Accept(this);
                result.Add(a);
            }

            return result;
        }

        public override AstBase VisitSql_stmt([NotNull] ElasticParser.Sql_stmtContext context)
        {
            return base.VisitSql_stmt(context);
        }

        /// <summary>
        /// select_stmt:
        ///    common_table_stmt? select_core
        ///    compound*
        ///    order_by_stmt? 
        ///    limit_stmt?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitSelect_stmt([NotNull] ElasticParser.Select_stmtContext context)
        {

            var table = context.common_table_stmt();
            if (table != null)
            {
                Stop();
                table.Accept(this);
            }

            var select = context.select_core();
            Specification SelectResult = (Specification)select.Accept(this);

            var operators = context.compound();
            if (operators != null)
            {
                foreach (var @operator in operators)
                {
                    Stop();
                    @operator.Accept(this);
                }
            }

            var order = context.order_by_stmt();
            if (order != null)
                SelectResult.Sort = (SpecificationSorting)order.Accept(this);

            var limit = context.limit_stmts();
            if (limit != null)
                SelectResult.Limit = (SpecificationLimit)limit.Accept(this);
            
            else
            {
                var locator = GetLocator(context);
                SelectResult.Limit = new SpecificationLimit(locator)
                {
                    Offset = new Literal(null) { Value = 0 },
                    RowCount = new Literal(null) { Value = 10 },
                };
            }

            return SelectResult;

        }

        /// <summary>
        /// select_core:
        ///    (
        ///        SELECT (DISTINCT | ALL)? 
        ///        result_column(',' result_column)*
        ///        (
        ///            FROM (table_or_subquery (',' table_or_subquery)* | join_clause)
        /// 	   )? 
        /// 	where_stmt? 
        /// 	group_by_stmt? 
        /// 	( WINDOW window_stmt(',' window_stmt)*)?)
        ///     | VALUES value_list_stmt;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitSelect_core([NotNull] ElasticParser.Select_coreContext context)
        {

            var distinct = context.DISTINCT() != null;
            var all = context.DISTINCT() != null;
            var window = context.WINDOW() != null;
            var values = context.VALUES() != null;

            var s = new Specification(GetLocator(context));

            if (context.FROM() != null)
                s.Source = (SpecificationSource)context.subquery_table().Accept(this);

            else if (values)
            {
                Stop();
                var c = context.value_list_stmt();
            }


            if (window)
            {
                Stop();
                var windows = context.window_stmt();
                foreach (var win in windows)
                {
                    win.Accept(this);
                }

            }


            var groupBy = context.group_by_stmt();
            if (groupBy != null)
            {
                Stop();
                groupBy.Accept(this);
            }

            var @where = context.where_stmt();
            if (@where != null)
                s.Filter = (SpecificationFilter)@where.Accept(this);

            var columns = context.result_column();
            if (columns != null)
            {
                var projection = new SpecificationProjection(GetLocator(context));
                foreach (var column in columns)
                    projection.Projections.Add(column.Accept(this));
                s.Projection = projection;
            }

            return s;

        }

        /// <summary>
        /// subquery_table: (table_or_subquery (',' table_or_subquery)* | join_clauses)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitSubquery_table([NotNull] ElasticParser.Subquery_tableContext context)
        {

            var subs = context.table_or_subquery();
            if (subs != null)
            {
                List<SpecificationSource> sources = new List<SpecificationSource>();
                foreach (var sub in subs)
                {
                    var source = sub.Accept(this);
                    if (source is SpecificationSource s)
                        sources.Add(s);

                    else if (source is AliasAstBase a)
                        sources.Add(new SpecificationSourceAlias(GetLocator(sub)) { Alias = a });

                    else
                    {
                        Stop();
                    }
                }

                var first = sources[0];
                sources.RemoveAt(0);

                first.Subs.AddRange(sources);

                return first;

            }

            Stop();

            return context.join_clauses().Accept(this);

        }

        /// <summary>
        /// result_column:
        ///     '*'
        ///     | table_name '.' '*'
        ///     | expr(AS? column_alias)?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitResult_column([NotNull] ElasticParser.Result_columnContext context)
        {
            Identifier i = null;
            var Wildcard = context.STAR() != null;
            if (Wildcard)
                i = new Identifier(GetLocator(context.STAR()))
                {
                    Text = "*",
                    Wildcard = true,
                    Kind = IdentifierKindEnum.ColumnReference,
                };

            var tablename = context.table_name();
            if (tablename != null)
            {
                var r = (Identifier)tablename.Accept(this);
                r.Kind = IdentifierKindEnum.TableReference;
                r.TargetRight = i;
                i = r;
            }
            else
            {
                var expr = context.expr();
                if (expr != null)
                {
                    var r = expr.Accept(this);
                    var _alias = context.column_alias();
                    if (_alias != null)
                    {
                        var alias = new AliasAstBase(GetLocator(_alias))
                        {
                            Value = r,
                            AliasName = (Identifier)_alias.Accept(this),
                        };
                        return alias;
                    }
                    return r;
                }
            }

            return i;

        }

        /// <summary>
        /// expr:
        ///       literal_value
        ///     | BIND_PARAMETER
        ///     | fullname
        ///     | unary_operator expr
        ///     | expr binary_operator expr
        ///     | function_name '(' ((DISTINCT? expr_list) | STAR)? ')' filter_clause? over_clause?
        ///     | CAST '(' expr AS type_name ')'
        ///     | expr COLLATE collation_name
        ///     | expr nullable_expr
        ///     | case_expr
        ///     | expr in_expr
        ///     | exists_expr
        ///     | raise_function
        ///     | expr NOT? BETWEEN expr AND expr
        ///     | expr NOT? like_operator expr(ESCAPE expr)?
        ///     | '(' (expr | expr_list) ')'
        ///     ;
        /// ;<returns></returns>
        public override AstBase VisitExpr([NotNull] ElasticParser.ExprContext context)
        {

            var e = context.expr();

            var literal = context.literal_value();
            if (literal != null)
                return literal.Accept(this);

            var parameterBind = context.BIND_PARAMETER();
            if (parameterBind != null)
            {
                var t = parameterBind.GetText();
                Stop();
                return new ParameterBind(GetLocator(parameterBind)) { Label = t };
            }

            var fullname = context.fullname();
            if (fullname != null)
                return fullname.Accept(this);

            var unary_operator = context.unary_operator();
            if (unary_operator != null)
                return GetUnaryExpression(unary_operator, e[0]);

            var binary_operator = context.binary_operator();
            if (binary_operator != null)
                return GetBinaryExpression(e[0], binary_operator, e[1]);

            var call_function_expr = context.call_function_expr();
            if (call_function_expr != null)
                return call_function_expr.Accept(this);

            if (context.CAST() != null)
                return GetCastExpression(e[0], context.type_name());

            if (context.COLLATE() != null)
                return GetCollateExpression(e[0], context.collation_name());

            var nullable = context.nullable_expr();
            if (nullable != null)
                return GetNullableExpression(e[0], context.nullable_expr());

            var case_expr = context.case_expression();
            if (case_expr != null) // CASE expr? (WHEN expr THEN expr)+ (ELSE expr)? END
                return case_expr.Accept(this);

            var raise_function = context.raise_function();
            if (raise_function != null)
                return raise_function.Accept(this);

            if (context.BETWEEN() != null) // expr NOT? BETWEEN expr AND expr
            {
                var ex = GetBetweenExpression(e[0], e[1], e[2]);
                if (context.NOT() != null)
                    return new UnaryExpression(GetLocator(e[0])) { Expression = ex, Operator = UnaryOperatorEnum.Not };
                return ex;
            }

            var like_operator = context.like_operator();
            if (like_operator != null) // expr NOT? like_operator expr(ESCAPE expr)?
            {
                var n = context.NOT() != null;
                var b = GetLikeExpression(e[0], e[1]);
                var es = context.ESCAPE() != null;
                Stop();
            }

            var in_expr = context.in_expr();
            if (in_expr != null)
            {
                var left = e[0].Accept(this);
                var right = in_expr.Accept(this);

                if (right is UnaryExpression u && u.Expression is BinaryExpression b1)
                    b1.Left = left;

                else if (right is BinaryExpression b)
                    b.Left = left;

                else
                {
                    Stop();
                }

                return right;
            }

            var exists_expr = context.exists_expr();
            if (exists_expr != null)
                return exists_expr.Accept(this);

            var expr_list = context.expr_list();
            if (expr_list != null)
                return expr_list.Accept(this);

            if (e.Length > 0)
                return e[0].Accept(this);

            Stop();
            return null;

        }

        /// <summary>
        /// function_name '(' ((DISTINCT? expr_list) | STAR)? ')' filter_clause? over_clause?
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitCall_function_expr([NotNull] ElasticParser.Call_function_exprContext context)
        {

            var f = new FunctionCall(GetLocator(context))
            {
                Name = (Identifier)context.function_name().Accept(this),
            };
            AstBase result = f;

            var l = context.expr_list();
            if (l != null)
            {
                var args = (AstList<AstBase>)l.Accept(this);
                f.Arguments.AddRange(args);
            }
            else if (context.STAR() != null)
                f.Arguments.Add(new Identifier(GetLocator(context.STAR())) { Text = "*" });

            if (context.DISTINCT() != null)
                result = new UnaryExpression(GetLocator(context.DISTINCT())) { Expression = result, Operator = UnaryOperatorEnum.Distinct };



            return f;
        }

        /// <summary>
        /// exists_expr : ((NOT)? EXISTS)? '(' select_stmt ')'
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitExists_expr([NotNull] ElasticParser.Exists_exprContext context)
        {

            var result = context.select_stmt().Accept(this);

            if (context.EXISTS() != null)
                result = new UnaryExpression(GetLocator(context.EXISTS())) { Expression = result, Operator = UnaryOperatorEnum.Exists };

            if (context.NOT() != null)
                result = new UnaryExpression(GetLocator(context.NOT())) { Expression = result, Operator = UnaryOperatorEnum.Not };

            return result;
        }

        /// <summary>
        ///  In_expr: 
        ///     NOT? IN
        ///     (
        ///           ('(' (select_stmt | expr_list)? ')')
        ///     	| ((schema_name '.')? table_name)
        ///     	| ((schema_name '.')? table_function_name '(' expr_list? ')')
        ///     )
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitIn_expr([NotNull] ElasticParser.In_exprContext context)
        {

            Stop();

            var result = new BinaryExpression(GetLocator(context))
            {
                Operator = BinaryOperatorEnum.In,
            };

            var select_stmt = context.select_stmt();
            if (select_stmt != null)
                result.Right = select_stmt.Accept(this);

            else
            {
                var schema = context.schema_name();

                var table = context.table_name();
                if (table != null)
                {
                    var t = (Identifier)table.Accept(this);
                    if (schema != null)
                    {
                        var s = (Identifier)schema.Accept(this);
                        s.TargetRight = t;
                        t = s;
                    }
                    result.Right = t;
                }
                else
                {

                    var list = context.expr_list();

                    var table_function_name = context.table_function_name();
                    if (table_function_name != null)
                    {
                        var t2 = (Identifier)table_function_name.Accept(this);
                        if (schema != null)
                        {
                            var s = (Identifier)schema.Accept(this);
                            s.TargetRight = t2;
                            t2 = s;
                        }

                        var f = new FunctionCall(GetLocator(table_function_name))
                        {
                            Name = t2,
                        };

                        if (list != null)
                            f.Arguments = (AstList<AstBase>)list.Accept(this);

                        result.Right = f;
                    }
                    else
                    {
                        if (list != null)
                            result.Right = list.Accept(this);
                        else
                            Stop();
                    }
                }

            }

            if (context.NOT() != null)
                return new UnaryExpression(GetLocator(context.NOT())) { Expression = result, Operator = UnaryOperatorEnum.Not };

            return result;

        }

        /// <summary>
        /// expr NOT? like_operator expr(ESCAPE expr)?
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private object GetLikeExpression(ElasticParser.ExprContext p1, ElasticParser.ExprContext p2)
        {
            Stop();
            return null;
        }

        /// <summary>
        /// expr NOT? BETWEEN expr AND expr
        /// </summary>
        /// <param name="exprContext1"></param>
        /// <param name="exprContext2"></param>
        /// <param name="exprContext3"></param>
        /// <returns></returns>
        private AstBase GetBetweenExpression(ElasticParser.ExprContext exprContext1, ElasticParser.ExprContext exprContext2, ElasticParser.ExprContext exprContext3)
        {
            Stop();
            return null;
        }

        /// <summary>
        /// case_expresion: case_expr case_when+ case_else_expr? END;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitCase_expression([NotNull] ElasticParser.Case_expressionContext context)
        {

            var c = new CaseExpression(GetLocator(context.case_expr()))
            {
                CaseExpr = context.case_expr().Accept(this)
            };


            var whens = context.case_when();
            foreach (var item in whens)
                c.Cases.Add((CaseWhenExpression)item.Accept(this));


            var caseElseExpr = context.case_else_expr();
            if (caseElseExpr != null)
                c.ElseExpr = caseElseExpr.Accept(this);

            return c;

        }

        /// <summary>
        /// WHEN expr THEN expr
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitCase_when([NotNull] ElasticParser.Case_whenContext context)
        {
            var e = context.expr();
            return new CaseWhenExpression(GetLocator(context))
            {
                WhenExpr = e[0].Accept(this),
                ThenExpr = e[1].Accept(this),
            };
        }

        /// <summary>
        /// case_expr: CASE expr? ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitCase_expr([NotNull] ElasticParser.Case_exprContext context)
        {
            var e = context.expr();
            if (e != null)
                return e.Accept(this);
            return null;
        }

        /// <summary>
        /// expr nullable_expr
        /// </summary>
        /// <param name="exprContexts"></param>
        /// <param name="nullable_exprContext"></param>
        /// <returns></returns>
        private AstBase GetNullableExpression(ElasticParser.ExprContext exprContexts, ElasticParser.Nullable_exprContext nullable_exprContext)
        {

            var u = new UnaryExpression(GetLocator(nullable_exprContext))
            {
                Expression = exprContexts.Accept(this),
            };

            if (nullable_exprContext.ISNULL() != null)
                u.Operator = UnaryOperatorEnum.IsNull;

            else if (nullable_exprContext.NOT() != null && nullable_exprContext.NULL_() != null)
                u.Operator = UnaryOperatorEnum.IsNotNull;

            else if (nullable_exprContext.NOTNULL() != null)
                u.Operator = UnaryOperatorEnum.IsNotNull;

            return u;

        }

        private AstBase GetCollateExpression(ElasticParser.ExprContext exprContexts, ElasticParser.Collation_nameContext collation_nameContext)
        {
            Stop();
            return null;
        }

        private AstBase GetCastExpression(ElasticParser.ExprContext exprContexts, ElasticParser.Type_nameContext type_nameContext)
        {
            return new CastExpression(GetLocator(type_nameContext))
            {
                Expression = exprContexts.Accept(this),
                TargetType = type_nameContext.Accept(this),
            };
        }

        private AstBase GetUnaryExpression(ElasticParser.Unary_operatorContext unary_operator, ElasticParser.ExprContext exprContext)
        {
            Stop();
            return null;
        }

        private AstBase GetBinaryExpression(ElasticParser.ExprContext leftExpr, ElasticParser.Binary_operatorContext binary_operator, ElasticParser.ExprContext rightExpr)
        {

            var l = leftExpr.Accept(this);
            var r = rightExpr.Accept(this);
            var o = BinaryOperatorEnum.Undefined;

            var txt = binary_operator.GetText().Split(' ');
            switch (txt[0])
            {
                case "=":
                case "==":
                    o = BinaryOperatorEnum.Equal;
                    break;
                case "!=":
                case "<>":
                    o = BinaryOperatorEnum.NotEqual;
                    break;

                case "*":
                    o = BinaryOperatorEnum.Multiply;
                    break;
                case "+":
                    o = BinaryOperatorEnum.Add;
                    break;
                case "-":
                    o = BinaryOperatorEnum.Remove;
                    break;
                case "/":
                    o = BinaryOperatorEnum.Div;
                    break;
                case "%":
                    o = BinaryOperatorEnum.Modulo;
                    break;

                case "<":
                    o = BinaryOperatorEnum.LessThan;
                    break;
                case ">":
                    o = BinaryOperatorEnum.GreaterThan;
                    break;
                case "<=":
                    o = BinaryOperatorEnum.LessOrEqualThan;
                    break;
                case ">=":
                    o = BinaryOperatorEnum.GreaterOrEqualThan;
                    break;

                case "||":
                    o = BinaryOperatorEnum.Concat;
                    break;

                case "AND":
                    o = BinaryOperatorEnum.And;
                    break;
                case "OR":
                    o = BinaryOperatorEnum.Or;
                    break;


                case "|":
                    o = BinaryOperatorEnum.BitwiseOr;
                    break;
                case "&":
                    o = BinaryOperatorEnum.BitwiseAnd;
                    break;

                case "<<":
                    o = BinaryOperatorEnum.LeftShift;
                    break;
                case ">>":
                    o = BinaryOperatorEnum.RightShift;
                    break;

                case "IN":
                    o = BinaryOperatorEnum.In;
                    break;

                case "IS":
                    Stop();
                    if (txt.Length == 0 && txt[1] == "NOT")
                        o = BinaryOperatorEnum.IsNot;
                    else
                        o = BinaryOperatorEnum.Is;
                    break;

                case "LIKE":
                    o = BinaryOperatorEnum.Like;
                    break;

                case "GLOB":
                    o = BinaryOperatorEnum.Glob;
                    break;
                case "MATCH":
                    o = BinaryOperatorEnum.Match;
                    break;

                case "REGEX":
                    o = BinaryOperatorEnum.Regex;
                    break;

                default:
                    Stop();
                    break;
            }

            return new BinaryExpression(GetLocator(binary_operator))
            {
                Left = l,
                Right = r,
                Operator = o
            };

        }

        public override AstBase VisitFullname([NotNull] ElasticParser.FullnameContext context)
        {

            Identifier i = null;

            var c = context.column_name();
            i = (Identifier)c.Accept(this);
            i.Kind = IdentifierKindEnum.ColumnReference;

            var t = context.table_name();
            if (t != null)
            {
                var j = (Identifier)t.Accept(this);
                j.Kind = IdentifierKindEnum.TableReference;
                j.TargetRight = i;
                i = j;
            }
            var s = context.schema_name();
            if (s != null)
            {
                var k = (Identifier)s.Accept(this);
                k.Kind = IdentifierKindEnum.ServerReference;
                k.TargetRight = i;
                i = k;
            }

            return i;
        }

        public override AstBase VisitTable_name([NotNull] ElasticParser.Table_nameContext context)
        {
            return context.any_name().Accept(this);
        }

        /// <summary>
        /// table_or_subquery: (
        ///     	(schema_name '.')? table_name(AS? table_alias)? (
        ///            (INDEXED BY index_name)
        ///     		| (NOT INDEXED)
        ///     	)?
        ///     )
        ///     | (
        ///         (schema_name '.')? table_function_name '(' expr(
        ///     		',' expr
        ///     
        ///         )* ')' (AS? table_alias)?
        ///     )
        ///     | '(' subquery_table ')'
        ///     | ('(' select_stmt ')' (AS? table_alias)?);
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitTable_or_subquery([NotNull] ElasticParser.Table_or_subqueryContext context)
        {

            Identifier schema = null;
            AstBase source = null;

            var s = context.schema_name();
            if (s != null)
            {
                schema = (Identifier)s.Accept(this);
                schema.Kind = IdentifierKindEnum.ServerReference;
            }

            var alias = context.table_alias();

            var t = context.table_name();
            if (t != null)
            {

                var tableName = (Identifier)t.Accept(this);
                tableName.Kind = IdentifierKindEnum.TableReference;
                if (schema != null)
                {
                    schema.TargetRight = tableName;
                    tableName = schema;
                }
                Identifier index = null;
                if (context.INDEXED() != null)
                    index = (Identifier)context.index_name().Accept(this);

                source = new SpecificationSourceTable(GetLocator(t))
                {
                    Name = tableName,
                    IndexedBy = index,
                };

                if (alias != null)
                    source = new AliasAstBase(GetLocator(alias))
                    {
                        AliasName = (Identifier)alias.Accept(this),
                        Value = source,
                    };


                return source;

            }

            var f = context.table_function_name();
            if (t != null)
            {

                Stop();

                var functionName = (Identifier)t.Accept(this);
                functionName.Kind = IdentifierKindEnum.FunctionReference;
                if (schema != null)
                {
                    schema.TargetRight = functionName;
                    functionName = schema;
                }
                var e = context.expr();
                AstList<AstBase> _args = new AstList<AstBase>(GetLocator(context));
                if (e != null)
                    foreach (var item in e)
                        _args.Add(item.Accept(this));

                source = new SpecificationSourceFunction(GetLocator(f))
                {
                    Function = new FunctionCall(GetLocator(t))
                    {
                        Name = functionName,
                        Arguments = _args,
                    }
                };


                if (alias != null)
                    source = new AliasAstBase(GetLocator(alias))
                    {
                        AliasName = (Identifier)alias.Accept(this),
                        Value = source,
                    };

                return source;

            }

            var sub = context.subquery_table();
            if (sub != null)
                return sub.Accept(this);

            Stop();

            AliasAstBase _alias = null;
            if (alias != null)
                _alias = new AliasAstBase(GetLocator(alias))
                {
                    AliasName = (Identifier)alias.Accept(this),
                };

            source = new SpecificationSourceSelect(GetLocator(context.select_stmt()))
            {
                Select = (Specification)context.select_stmt().Accept(this),
                ShortName = _alias
            };



            return source;

        }

        /// <summary>
        /// join_clauses: table_or_subquery join_clause+;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitJoin_clauses([NotNull] ElasticParser.Join_clausesContext context)
        {
            Stop();
            SpecificationSource left = (SpecificationSource)context.table_or_subquery().Accept(this);

            var rights = context.join_clause();
            foreach (var right in rights)
                left.Subs.Add((SpecificationSource)right.Accept(this));

            return left;
        }

        /// <summary>
        /// join_clause: join_operator table_or_subquery join_constraint?;
        /// 
        /// join_operator:
        ///     ','
        ///     | (NATURAL? ((LEFT OUTER?) | INNER | CROSS)? JOIN);
        ///     
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitJoin_clause([NotNull] ElasticParser.Join_clauseContext context)
        {

            Stop();

            var ope = context.join_operator();
            var right = context.table_or_subquery().Accept(this);

            var join_constraint = context.join_constraint();
            if (join_constraint != null)
            {

                var o = join_constraint.Accept(this);
            }


            var n = ope.NATURAL() != null;

            if (ope.OUTER() != null)
            {

            }
            else if (ope.CROSS() != null)
            {

            }
            else if (ope.INNER() != null)
            {

            }

            return base.VisitJoin_clause(context);

        }

        /// <summary>
        /// join_constraint:
        ///      (ON expr)
        ///    | (USING column_name_list);
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitJoin_constraint([NotNull] ElasticParser.Join_constraintContext context)
        {
            Stop();
            if (context.ON() != null)
                return context.expr().Accept(this);

            return context.column_name_list().Accept(this);
        }

        /// <summary>
        /// order_by_stmt: ORDER BY ordering_term ( ',' ordering_term)*;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitOrder_by_stmt([NotNull] ElasticParser.Order_by_stmtContext context)
        {
            SpecificationSorting _items = new SpecificationSorting(GetLocator(context));
            var terms = context.ordering_term();
            foreach (var item in terms)
                _items.Sorts.Add((SpecificationSortItem)item.Accept(this));
            return _items;
        }

        /// <summary>
        /// ordering_term:
        ///     expr(COLLATE collation_name)? asc_desc? 
        ///     (NULLS (FIRST | LAST))?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitOrdering_term([NotNull] ElasticParser.Ordering_termContext context)
        {

            var sort = new SpecificationSortItem(GetLocator(context));

            var e = context.expr();
            if (e != null)
            {

                sort.Expression = e.Accept(this);

                var f = e.Accept(this);
                if (context.COLLATE() != null)
                {

                    sort.CollationName = (Identifier)context.collation_name().Accept(this);
                }
            }

            sort.AscSort = true;
            var asc = context.asc_desc();
            if (asc != null)
                sort.AscSort = !(asc.DESC() != null);

            if (context.NULLS() != null)
            {
                Stop();
            }

            return sort;

        }

        ///// <summary>
        ///// asc_desc: ASC | DESC;
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override AstBase VisitAsc_desc([NotNull] ElasticParser.Asc_descContext context)
        //{
        //    Stop();
        //    return base.VisitAsc_desc(context);
        //}

        /// <summary>
        /// limit_stmts: LIMIT expr ( (OFFSET | ',') expr)?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitLimit_stmts([NotNull] ElasticParser.Limit_stmtsContext context)
        {

            Stop();

            Literal offset = null;
            var rowCount = (Literal)context.expr().Accept(this);

            var f = context.limit_stmt();
            if (f != null)
            {

                if (f.OFFSET() != null)
                {
                    offset = (Literal)f.expr().Accept(this);
                }
                else
                {
                    offset = rowCount;
                    rowCount = (Literal)f.expr().Accept(this);
                }

            }

            SpecificationLimit limit = new SpecificationLimit(GetLocator(f))
            {
                RowCount = rowCount,
                Offset = offset,

            };

            return limit;

        }

        public override AstBase VisitOrder_by_expr([NotNull] ElasticParser.Order_by_exprContext context)
        {
            Stop();
            return base.VisitOrder_by_expr(context);
        }

        public override AstBase VisitOrder_by_expr_asc_desc([NotNull] ElasticParser.Order_by_expr_asc_descContext context)
        {
            Stop();
            return base.VisitOrder_by_expr_asc_desc(context);
        }

        public override AstBase VisitLike_operator([NotNull] ElasticParser.Like_operatorContext context)
        {
            Stop();
            return base.VisitLike_operator(context);
        }

        public override AstBase VisitNullable_expr([NotNull] ElasticParser.Nullable_exprContext context)
        {
            Stop();
            return base.VisitNullable_expr(context);
        }

        public override AstBase VisitBinary_operator([NotNull] ElasticParser.Binary_operatorContext context)
        {
            Stop();
            return base.VisitBinary_operator(context);
        }

        /// <summary>
        /// column_alias: IDENTIFIER | STRING_LITERAL;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitColumn_alias([NotNull] ElasticParser.Column_aliasContext context)
        {
            Stop();
            var i = context.IDENTIFIER();
            var k = context.STRING_LITERAL();

            return new AliasAstBase(GetLocator(context))
            {
                AliasName = (Identifier)i.Accept(this),
                Value = k.Accept(this),
            };

        }

        /// <summary>
        /// any_name:
        ///         IDENTIFIER
        ///     | keyword
        ///     | STRING_LITERAL
        ///     | '(' any_name ')';
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitAny_name([NotNull] ElasticParser.Any_nameContext context)
        {

            var i = context.IDENTIFIER();
            if (i != null)
                return i.Accept(this);

            var j = context.keyword();
            if (j != null)
                return j.Accept(this);

            var k = context.STRING_LITERAL();
            if (k != null)
                return k.Accept(this);

            var l = context.any_name();
            var r = (Identifier)l.Accept(this);
            r.WithParenthesis = true;

            return r;

        }

        public override AstBase VisitTerminal(ITerminalNode node)
        {
            return GetIdentifier(node);
        }

        /// <summary>
        /// literal_value:
        ///       NUMERIC_LITERAL
        ///     | STRING_LITERAL
        ///     | BLOB_LITERAL
        ///     | NULL_
        ///     | TRUE_
        ///     | FALSE_
        ///     | CURRENT_TIME
        ///     | CURRENT_DATE
        ///     | CURRENT_TIMESTAMP;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitLiteral_value([NotNull] ElasticParser.Literal_valueContext context)
        {

            var true_ = context.TRUE_();
            if (true_ != null)
                return new Literal(GetLocator(context)) { Value = true };

            var false_ = context.FALSE_();
            if (false_ != null)
                return new Literal(GetLocator(context)) { Value = false };

            var null_ = context.NULL_();
            if (null_ != null)
                return new Literal(GetLocator(context)) { Value = null };

            if (context.CURRENT_TIME() != null)
                return new Literal(GetLocator(context)) { Value = DateTimeOffset.Now };

            if (context.CURRENT_DATE() != null)
                return new Literal(GetLocator(context)) { Value = DateTime.Now };

            if (context.CURRENT_TIMESTAMP() != null)
                return new Literal(GetLocator(context)) { Value = DateTimeOffset.Now };

            var txt = context.GetText();

            var text = context.STRING_LITERAL();
            if (text != null)
                return new Literal(GetLocator(context)) { Value = txt.Trim('\'') };

            var numeric = context.NUMERIC_LITERAL();
            if (numeric != null)
            {

                Stop();

                var numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                if (txt.Contains(numberDecimalSeparator))
                    return new Literal(GetLocator(context)) { Value = Convert.ChangeType(txt, typeof(double)) };

                else
                {
                    Stop();
                    var v = (long)Convert.ChangeType(txt, typeof(long));
                    if (v > int.MaxValue)
                        return new Literal(GetLocator(context)) { Value = v };
                    return new Literal(GetLocator(context)) { Value = (int)v };
                }

            }

            var blob = context.BLOB_LITERAL();
            if (blob != null)
            {
                Stop();

            }

            Stop();

            return new Literal(GetLocator(context)) { Value = txt };

        }

        public override AstBase VisitKeyword([NotNull] ElasticParser.KeywordContext context)
        {
            var i = (Identifier)GetIdentifier(context.GetText(), GetLocator(context));
            i.IsKeywork = true;
            return i;
        }

        /// <summary>
        /// column_name_list: '(' column_name (',' column_name)* ')';
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitColumn_name_list([NotNull] ElasticParser.Column_name_listContext context)
        {
            var columns = context.column_name();
            IdentifierList list = new IdentifierList(GetLocator(context));
            foreach (var item in columns)
                list.Add((Identifier)item.Accept(this));
            return list;
        }

        /// <summary>
        /// common_table_stmt: //additional structures
        ///     WITH RECURSIVE? common_table_expression(
        ///     ',' common_table_expression
        ///     
        ///     )*;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override AstBase VisitCommon_table_stmt([NotNull] ElasticParser.Common_table_stmtContext context)
        {
            Stop();
            return base.VisitCommon_table_stmt(context);
        }

        public override AstBase VisitTable_alias([NotNull] ElasticParser.Table_aliasContext context)
        {
            return base.VisitTable_alias(context);
        }

        public override AstBase VisitCompound_operator([NotNull] ElasticParser.Compound_operatorContext context)
        {
            Stop();
            return base.VisitCompound_operator(context);
        }

        public override AstBase VisitExpr_list([NotNull] ElasticParser.Expr_listContext context)
        {
            Stop();
            return base.VisitExpr_list(context);
        }

        public override AstBase VisitGroup_by_stmt([NotNull] ElasticParser.Group_by_stmtContext context)
        {
            Stop();
            return base.VisitGroup_by_stmt(context);
        }

        public override AstBase VisitHaving_stmt([NotNull] ElasticParser.Having_stmtContext context)
        {
            Stop();
            return base.VisitHaving_stmt(context);
        }

        public override AstBase VisitValue_list_stmt([NotNull] ElasticParser.Value_list_stmtContext context)
        {
            Stop();
            return base.VisitValue_list_stmt(context);
        }

        public override AstBase VisitWhere_stmt([NotNull] ElasticParser.Where_stmtContext context)
        {
            var s = new SpecificationFilter(GetLocator(context))
            {
                Filter = context.expr().Accept(this),
            };
            return s;
        }

        public override AstBase VisitWindow_stmt([NotNull] ElasticParser.Window_stmtContext context)
        {
            Stop();
            return base.VisitWindow_stmt(context);
        }

        public override AstBase VisitAggregate_func([NotNull] ElasticParser.Aggregate_funcContext context)
        {
            Stop();
            return base.VisitAggregate_func(context);
        }

        public override AstBase VisitAlias([NotNull] ElasticParser.AliasContext context)
        {
            Stop();
            return base.VisitAlias(context);
        }

        public override AstBase VisitBase_window_name([NotNull] ElasticParser.Base_window_nameContext context)
        {
            Stop();
            return base.VisitBase_window_name(context);
        }

        public override AstBase VisitCollation_name([NotNull] ElasticParser.Collation_nameContext context)
        {
            Stop();
            return base.VisitCollation_name(context);
        }

        public override AstBase VisitColumn_constraint([NotNull] ElasticParser.Column_constraintContext context)
        {
            Stop();
            return base.VisitColumn_constraint(context);
        }

        public override AstBase VisitColumn_def([NotNull] ElasticParser.Column_defContext context)
        {
            Stop();
            return base.VisitColumn_def(context);
        }

        public override AstBase VisitCommon_table_expression([NotNull] ElasticParser.Common_table_expressionContext context)
        {
            Stop();
            return base.VisitCommon_table_expression(context);
        }

        public override AstBase VisitConflict_clause([NotNull] ElasticParser.Conflict_clauseContext context)
        {
            Stop();
            return base.VisitConflict_clause(context);
        }

        public override AstBase VisitCreate_table_stmt([NotNull] ElasticParser.Create_table_stmtContext context)
        {
            Stop();
            return base.VisitCreate_table_stmt(context);
        }

        public override AstBase VisitCreate_view_stmt([NotNull] ElasticParser.Create_view_stmtContext context)
        {
            Stop();
            return base.VisitCreate_view_stmt(context);
        }

        public override AstBase VisitCreate_virtual_table_stmt([NotNull] ElasticParser.Create_virtual_table_stmtContext context)
        {
            Stop();
            return base.VisitCreate_virtual_table_stmt(context);
        }

        public override AstBase VisitCte_table_name([NotNull] ElasticParser.Cte_table_nameContext context)
        {
            Stop();
            return base.VisitCte_table_name(context);
        }

        public override AstBase VisitDefault_value([NotNull] ElasticParser.Default_valueContext context)
        {
            Stop();
            return base.VisitDefault_value(context);
        }

        public override AstBase VisitError([NotNull] ElasticParser.ErrorContext context)
        {
            Stop();
            return base.VisitError(context);
        }

        public override AstBase VisitErrorNode(IErrorNode node)
        {
            Stop();
            return base.VisitErrorNode(node);
        }

        public override AstBase VisitError_message([NotNull] ElasticParser.Error_messageContext context)
        {
            Stop();
            return base.VisitError_message(context);
        }

        public override AstBase VisitFilter_clause([NotNull] ElasticParser.Filter_clauseContext context)
        {
            Stop();
            return base.VisitFilter_clause(context);
        }

        public override AstBase VisitForeign_key_clause([NotNull] ElasticParser.Foreign_key_clauseContext context)
        {
            Stop();
            return base.VisitForeign_key_clause(context);
        }

        public override AstBase VisitForeign_table([NotNull] ElasticParser.Foreign_tableContext context)
        {
            Stop();
            return base.VisitForeign_table(context);
        }

        public override AstBase VisitFrame_clause([NotNull] ElasticParser.Frame_clauseContext context)
        {
            Stop();
            return base.VisitFrame_clause(context);
        }

        public override AstBase VisitFrame_left([NotNull] ElasticParser.Frame_leftContext context)
        {
            Stop();
            return base.VisitFrame_left(context);
        }

        public override AstBase VisitFrame_right([NotNull] ElasticParser.Frame_rightContext context)
        {
            Stop();
            return base.VisitFrame_right(context);
        }

        public override AstBase VisitFrame_single([NotNull] ElasticParser.Frame_singleContext context)
        {
            Stop();
            return base.VisitFrame_single(context);
        }

        public override AstBase VisitFrame_spec([NotNull] ElasticParser.Frame_specContext context)
        {
            Stop();
            return base.VisitFrame_spec(context);
        }

        public override AstBase VisitFunction_name([NotNull] ElasticParser.Function_nameContext context)
        {
            Stop();
            return base.VisitFunction_name(context);
        }

        public override AstBase VisitIndexed_column([NotNull] ElasticParser.Indexed_columnContext context)
        {
            Stop();
            return base.VisitIndexed_column(context);
        }

        public override AstBase VisitIndex_name([NotNull] ElasticParser.Index_nameContext context)
        {
            Stop();
            return base.VisitIndex_name(context);
        }

        public override AstBase VisitInitial_select([NotNull] ElasticParser.Initial_selectContext context)
        {
            Stop();
            return base.VisitInitial_select(context);
        }

        public override AstBase VisitInsert_stmt([NotNull] ElasticParser.Insert_stmtContext context)
        {
            Stop();
            return base.VisitInsert_stmt(context);
        }

        public override AstBase VisitModule_argument([NotNull] ElasticParser.Module_argumentContext context)
        {
            Stop();
            return base.VisitModule_argument(context);
        }

        public override AstBase VisitModule_name([NotNull] ElasticParser.Module_nameContext context)
        {
            Stop();
            return base.VisitModule_name(context);
        }

        public override AstBase VisitName([NotNull] ElasticParser.NameContext context)
        {
            Stop();
            return base.VisitName(context);
        }

        public override AstBase VisitOffset([NotNull] ElasticParser.OffsetContext context)
        {
            Stop();
            return base.VisitOffset(context);
        }

        public override AstBase VisitOver_clause([NotNull] ElasticParser.Over_clauseContext context)
        {
            Stop();
            return base.VisitOver_clause(context);
        }

        public override AstBase VisitParse([NotNull] ElasticParser.ParseContext context)
        {
            Stop();
            return base.VisitParse(context);
        }

        public override AstBase VisitPartition_by([NotNull] ElasticParser.Partition_byContext context)
        {
            Stop();
            return base.VisitPartition_by(context);
        }

        public override AstBase VisitRaise_function([NotNull] ElasticParser.Raise_functionContext context)
        {
            Stop();
            return base.VisitRaise_function(context);
        }

        public override AstBase VisitRecursive_cte([NotNull] ElasticParser.Recursive_cteContext context)
        {
            Stop();
            return base.VisitRecursive_cte(context);
        }

        public override AstBase VisitRecursive_select([NotNull] ElasticParser.Recursive_selectContext context)
        {
            Stop();
            return base.VisitRecursive_select(context);
        }

        public override AstBase VisitSigned_number([NotNull] ElasticParser.Signed_numberContext context)
        {
            Stop();
            return base.VisitSigned_number(context);
        }

        public override AstBase VisitSimple_func([NotNull] ElasticParser.Simple_funcContext context)
        {
            Stop();
            return base.VisitSimple_func(context);
        }

        public override AstBase VisitTable_constraint([NotNull] ElasticParser.Table_constraintContext context)
        {
            Stop();
            return base.VisitTable_constraint(context);
        }

        public override AstBase VisitTable_function_name([NotNull] ElasticParser.Table_function_nameContext context)
        {
            Stop();
            return base.VisitTable_function_name(context);
        }

        public override AstBase VisitType_name([NotNull] ElasticParser.Type_nameContext context)
        {
            Stop();
            return base.VisitType_name(context);
        }

        public override AstBase VisitUnary_operator([NotNull] ElasticParser.Unary_operatorContext context)
        {
            Stop();
            return base.VisitUnary_operator(context);
        }

        public override AstBase VisitUpsert_clause([NotNull] ElasticParser.Upsert_clauseContext context)
        {
            Stop();
            return base.VisitUpsert_clause(context);
        }

        public override AstBase VisitView_name([NotNull] ElasticParser.View_nameContext context)
        {
            Stop();
            return base.VisitView_name(context);
        }

        public override AstBase VisitWindow_defn([NotNull] ElasticParser.Window_defnContext context)
        {
            Stop();
            return base.VisitWindow_defn(context);
        }

        public override AstBase VisitWindow_function([NotNull] ElasticParser.Window_functionContext context)
        {
            Stop();
            return base.VisitWindow_function(context);
        }

        public override AstBase VisitWindow_name([NotNull] ElasticParser.Window_nameContext context)
        {
            Stop();
            return base.VisitWindow_name(context);
        }

        public override AstBase VisitWith_clause([NotNull] ElasticParser.With_clauseContext context)
        {

            Stop();
            return base.VisitWith_clause(context);
        }


        private Identifier GetIdentifier(ITerminalNode node)
        {
            return GetIdentifier(node.GetText().Trim(), GetLocator(node));
        }

        private static Identifier GetIdentifier(string txt, Locator position)
        {
            return new Identifier(position)
            {
                Text = txt.Trim('\''),
                Quoted = txt.Contains('\''),
                WithParenthesis = txt.StartsWith('(') && txt.StartsWith(')'),
            };
        }

        private void EvaluateErrors(IParseTree item)
        {

            if (item != null)
            {

                if (item is ErrorNodeImpl e)
                    _ctx.Trace.AddError(new ResultMessageModel()
                    {
                        Position = GetLocator(e),
                        Text = e.Symbol.Text,
                        Message = $"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} ' {e.Symbol.Text}'",
                        Code = ResultMessageModelEnum.SyntaxtError,
                        Severity = ResultMessageModelSeverityEnum.Error,
                    });

                int c = item.ChildCount;
                for (int i = 0; i < c; i++)
                    EvaluateErrors(item.GetChild(i));

            }

        }

        public Locator GetLocator(Antlr4.Runtime.ParserRuleContext e)
        {
            return new Locator(e);
        }

        public Locator GetLocator(ITerminalNode e)
        {
            return new Locator(e);
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void Stop()
        {

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();

        }

        private readonly ContextExecutor _ctx;
        private readonly CultureInfo _currentCulture;


        //protected override object AggregateResult(object aggregate, object nextResult)
        //{
        //    Stop();
        //    return base.AggregateResult(aggregate, nextResult);
        //}

        //protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
        //{
        //    Stop();
        //    return base.ShouldVisitNextChild(node, currentResult);
        //}

        //public override AstBase VisitChildren(IRuleNode node)
        //{
        //    Stop();
        //    return base.VisitChildren(node);
        //}


    }
}
