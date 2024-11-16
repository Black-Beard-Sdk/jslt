using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Expressions.CsharpGenerators
{

    public class SourceCodeDomGenerator
    {

        private SourceCodeDomGenerator(string @namespace, string classname, string methodname, string[] usings, bool withDebug)
        {

            this._withDebug = withDebug;
            this._methodname = methodname;
            this._fields = new Dictionary<object, CodeMemberField>();

            this._namespaceRoot = new CodeNamespace(@namespace);
            this._typeRoot = new CodeTypeDeclaration(classname);
            this._namespaceRoot.Types.Add(_typeRoot);

            this._usings = new HashSet<string>(usings);
            this._usings.Add("System");
            this._usings.Add("System.Diagnostics");
            
        }

        public static CodeNamespace GetCode(Expression e, string @namespace, string classname, string methodname, bool withDebug, params string[] usings)
        {
            SourceCodeDomGenerator s = new SourceCodeDomGenerator(@namespace, classname, methodname, usings, withDebug);
            s.Parse(e);
            return s._namespaceRoot;
        }


        private void Parse(Expression e)
        {

            ExpressionCollectUsing.Collect(e, this._usings);

            foreach (var item in this._usings.OrderBy(c => c))
                this._namespaceRoot.Imports.Add(new CodeNamespaceImport(item));

            Visit(e);

            CreatePrivateMethod();

        }

        protected object Visit(Expression e)
        {

            switch (e.NodeType)
            {

                case ExpressionType.Conditional:
                    return VisitConditional((ConditionalExpression)e);

                case ExpressionType.Constant:
                    return VisitConstant((ConstantExpression)e);

                case ExpressionType.Call:
                    return VisitMethodCall((MethodCallExpression)e);

                case ExpressionType.MemberAccess:
                    return VisitMember((MemberExpression)e);

                case ExpressionType.MemberInit:
                    return VisitMemberInit((MemberInitExpression)e);

                case ExpressionType.New:
                    return VisitNew((NewExpression)e);

                case ExpressionType.NewArrayInit:
                    return VisitNewArray((NewArrayExpression)e);

                case ExpressionType.NewArrayBounds:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Parameter:
                    return VisitParameter((ParameterExpression)e);

                case ExpressionType.Block:
                    return VisitBlock((BlockExpression)e);

                case ExpressionType.DebugInfo:
                    return VisitDebugInfo((DebugInfoExpression)e);

                case ExpressionType.Default:
                    return VisitDefault((DefaultExpression)e);

                case ExpressionType.Goto:
                    return VisitGoto((GotoExpression)e);

                case ExpressionType.Dynamic:
                    return VisitDynamic((DynamicExpression)e);

                case ExpressionType.Index:
                    return VisitIndex((IndexExpression)e);

                case ExpressionType.Label:
                    return VisitLabel((LabelExpression)e);

                case ExpressionType.RuntimeVariables:
                    return VisitRuntimeVariables((RuntimeVariablesExpression)e);

                case ExpressionType.Loop:
                    return VisitLoop((LoopExpression)e);

                case ExpressionType.Switch:
                    return VisitSwitch((SwitchExpression)e);

                case ExpressionType.Try:
                    return VisitTry((TryExpression)e);

                case ExpressionType.Lambda:
                    return VisitLambda((LambdaExpression)e);

                case ExpressionType.ConvertChecked:
                case ExpressionType.Convert:
                    return VisitConvert((UnaryExpression)e);

                case ExpressionType.Assign:
                    return VisitAssign((BinaryExpression)e);

                case ExpressionType.TypeIs:
                    return VisitTypeIs((TypeBinaryExpression)e);


                case ExpressionType.Equal:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.ValueEquality);
                case ExpressionType.NotEqual:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.IdentityInequality);


                case ExpressionType.GreaterThan:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.GreaterThan);
                case ExpressionType.GreaterThanOrEqual:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.GreaterThanOrEqual);
                case ExpressionType.LessThan:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.LessThan);
                case ExpressionType.LessThanOrEqual:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.LessThanOrEqual);


                case ExpressionType.AddChecked:
                case ExpressionType.Add:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.Add);
                case ExpressionType.Divide:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.Divide);
                case ExpressionType.Modulo:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.Modulus);
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Multiply:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.Multiply);
                case ExpressionType.SubtractChecked:
                case ExpressionType.Subtract:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.Subtract);

                case ExpressionType.Power:
                    break;

                case ExpressionType.AddAssign:
                case ExpressionType.AddAssignChecked:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.Add);

                case ExpressionType.MultiplyAssign:
                case ExpressionType.MultiplyAssignChecked:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.Multiply);

                case ExpressionType.SubtractAssign:
                case ExpressionType.SubtractAssignChecked:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.Subtract);

                case ExpressionType.DivideAssign:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.Divide);

                case ExpressionType.ModuloAssign:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.Modulus);

                case ExpressionType.ExclusiveOrAssign:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.BooleanOr);

                case ExpressionType.OrAssign:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.BooleanOr);

                case ExpressionType.AndAssign:
                    return VisitBinaryOperationAssign((BinaryExpression)e, CodeBinaryOperatorType.BitwiseAnd);

                case ExpressionType.PowerAssign:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Or:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.BooleanOr);

                case ExpressionType.And:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.BooleanAnd);

                case ExpressionType.ExclusiveOr:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.BooleanAnd);

                case ExpressionType.AndAlso:
                    return VisitBinaryOperation((BinaryExpression)e, CodeBinaryOperatorType.BooleanAnd);

                case ExpressionType.OrElse:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.NegateChecked:
                case ExpressionType.UnaryPlus:
                case ExpressionType.Not:
                case ExpressionType.Negate:
                case ExpressionType.IsTrue:
                case ExpressionType.IsFalse:
                case ExpressionType.Decrement:
                case ExpressionType.Increment:
                    return VisitUnaryOperation((UnaryExpression)e);

                case ExpressionType.Invoke:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.ArrayLength:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.ArrayIndex:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Coalesce:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.ListInit:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Quote:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.TypeAs:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Extension:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Throw:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.Unbox:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.LeftShiftAssign:
                case ExpressionType.RightShiftAssign:
                    LocalDebug.Stop();
                    break;
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.PreDecrementAssign:
                    LocalDebug.Stop();
                    break;
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.PostDecrementAssign:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.TypeEqual:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.OnesComplement:
                    LocalDebug.Stop();
                    break;

                default:
                    LocalDebug.Stop();
                    return VisitExtension(e);

            }

            // return VisitTypeBinary((TypeBinaryExpression)e);
            // return VisitUnary((UnaryExpression)e);
            //return VisitInvocation((InvocationExpression)e);
            //return VisitListInit((ListInitExpression)e);

            return null;

        }

        private object VisitBinaryOperation(BinaryExpression e, CodeBinaryOperatorType ope)
        {
            var left = (CodeExpression)Visit(e.Left);
            var right = (CodeExpression)Visit(e.Right);
            return new CodeBinaryOperatorExpression(left, ope, right);
        }

        private object VisitBinaryOperationAssign(BinaryExpression e, CodeBinaryOperatorType ope)
        {
            var left = (CodeExpression)Visit(e.Left);
            var right = (CodeExpression)Visit(e.Right);
            return new CodeAssignStatement(left, new CodeBinaryOperatorExpression(left, ope, right));
        }

        private object VisitUnaryOperation(UnaryExpression e)
        {
            var left = (CodeExpression)Visit(e.Operand);

            switch (e.NodeType)
            {

                case ExpressionType.Not:
                    return new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Negate", left);

                case ExpressionType.NegateChecked:
                case ExpressionType.Negate:
                    return new CodeBinaryOperatorExpression(left, CodeBinaryOperatorType.Multiply, new CodePrimitiveExpression(-1));

                case ExpressionType.Increment:
                    return new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Increment", left);

                case ExpressionType.Decrement:
                    return new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Decrement", left);

                case ExpressionType.IsTrue:
                    return new CodeBinaryOperatorExpression(left, CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(true));

                case ExpressionType.IsFalse:
                    return new CodeBinaryOperatorExpression(left, CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(false));

                case ExpressionType.UnaryPlus:
                default:
                    LocalDebug.Stop();
                    break;
            }

            return null;

        }

        protected void CreatePrivateMethod()
        {

            // Create Not method because codeDom don't support unary opérateur
            var method = new CodeMemberMethod() { Name = "Not", ReturnType = typeof(bool).ToRefType(_usings) };
            this._typeRoot.Members.Add(method);
            method.Parameters.Add(new CodeParameterDeclarationExpression(typeof(bool), "self"));
            var code = new CodeConditionStatement(new CodeVariableReferenceExpression("self"));
            code.TrueStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(false)));
            code.FalseStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(true)));
            method.Statements.Add(code);

            // Create increment method because codeDom don't support unary opérateur
            method = new CodeMemberMethod() { Name = "Increment", ReturnType = typeof(int).ToRefType(_usings) };
            this._typeRoot.Members.Add(method);
            method.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "self") { Direction = FieldDirection.In });
            var self = new CodeVariableReferenceExpression("self");
            method.Statements.Add(new CodeAssignStatement(self, new CodeBinaryOperatorExpression(self, CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1))));
            method.Add(new CodeMethodReturnStatement(self));

            // Create increment method because codeDom don't support unary opérateur
            method = new CodeMemberMethod() { Name = "Decrement", ReturnType = typeof(int).ToRefType(_usings) };
            this._typeRoot.Members.Add(method);
            method.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "self") { Direction = FieldDirection.In });
            self = new CodeVariableReferenceExpression("self");
            method.Statements.Add(new CodeAssignStatement(self, new CodeBinaryOperatorExpression(self, CodeBinaryOperatorType.Subtract, new CodePrimitiveExpression(1))));
            method.Add(new CodeMethodReturnStatement(self));

        }

        protected object VisitLambda(LambdaExpression node)
        {

            this._methodRoot = new CodeMemberMethod() { Name = this._methodname, ReturnType = node.ReturnType.ToRefType(_usings), Attributes = MemberAttributes.Public };
            this._typeRoot.Members.Add(this._methodRoot);

            foreach (var item in node.Parameters)
                this._methodRoot.Parameters.Add(item.ToParameter(_usings));

            if (this._withDebug)
            {
                var stop = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression("argContext"), "Stop");
                this._methodRoot.Statements.Add(stop);
            }

            if (node.Body is BlockExpression b)
            {
                var block = VisitBlock(b);

                if (node.ReturnType != typeof(void))
                {
                    if (_last == null)
                    {
                        _last = block[block.Count - 1];
                        block.RemoveAt(block.Count - 1);
                    }

                    if (_last is CodeExpressionStatement s)
                    {
                        var result = new CodeMethodReturnStatement(s.Expression);
                        block.Add(result);
                    }
                    else
                    {
                        LocalDebug.Stop();
                    }
                }

                this._methodRoot.Add(block);

            }
            else
            {
                var e = Visit(node.Body);

                if (e != null)
                {
                    if (node.ReturnType != typeof(void))
                    {
                        if (e is CodeExpression expression)
                            this._methodRoot.Add(new CodeMethodReturnStatement(expression));

                        else
                        {
                            LocalDebug.Stop();
                        }
                    }
                }
            }

            var ctor = new CodeConstructor() { Attributes = MemberAttributes.Public };
            ctor.Parameters.Add(new CodeParameterDeclarationExpression() { Name = "args", Type = typeof(object[]).ToRefType(_usings), Direction = FieldDirection.In });
            this._typeRoot.Members.Add(ctor);

            var args = new CodeVariableReferenceExpression("args");
            int index = 0;
            foreach (var item in this._fields)
            {
                this._typeRoot.Members.Add(item.Value);
                var left = item.Value.GetReference();
                var right = new CodeArrayIndexerExpression(args, index.ToPrimitive());
                ctor.Statements.Add(left.AssignFrom(new CodeCastExpression(item.Value.Type, right)));

                index++;

            }

            return this._methodRoot;

        }

        protected List<CodeStatement> VisitBlock(BlockExpression node)
        {

            List<CodeStatement> list = new List<CodeStatement>(node.Expressions.Count);

            foreach (var item in node.Variables)
            {
                var d = item.DeclareVariable(_usings);
                if (!string.IsNullOrEmpty(d.Name))
                    list.Add(d);

            }

            foreach (var item in node.Expressions)
            {
                _last = null;
                var resultItem = Visit(item);
                if (resultItem != null)
                {

                    if (resultItem is List<CodeStatement> l)
                    {
                        foreach (var item2 in l)
                            list.Add(item2);

                        if (node.Type != typeof(void))
                        {
                            this._last = list[list.Count - 1];
                            list.RemoveAt(list.Count - 1);
                        }

                    }

                    else if (resultItem is CodeStatement t)
                        list.Add(t);

                    else if (resultItem is CodeExpression e)
                        list.Add(new CodeExpressionStatement(e));

                    else
                    {
                        LocalDebug.Stop();
                    }
                }

            }

            return list;

        }

        protected object VisitParameter(ParameterExpression node)
        {

            if (string.IsNullOrEmpty(node.Name))
            {

                if (!_variables.TryGetValue(node, out string name))
                {
                    name = $"var{node.ToString()}_{_variables.Count}";
                    _variables.Add(node, name);

                    return new CodeParameterDeclarationExpression(new CodeTypeReference("var"), name);

                }

                return new CodeVariableReferenceExpression(name);

            }

            return new CodeVariableReferenceExpression(node.Name);

        }

        protected object VisitMethodCall(MethodCallExpression node)
        {

            string name = node.Method.Name;

            CodeExpression targetObject = null;
            if (node.Method.IsStatic)
                targetObject = node.Method.DeclaringType.ToRefExpression(_usings);

            else
                targetObject = (CodeExpression)Visit(node.Object);

            if (name == "op_Implicit")
                return (CodeExpression)Visit(node.Arguments[0]);

            if (name == "op_Explicit")
            {
                if (node.Method.ReturnType.IsAssignableFrom(node.Type))
                {
                    var target = (CodeExpression)Visit(node.Arguments[0]);
                    return new CodeCastExpression(node.Type.ToRefType(_usings), target);

                }
            }

            var call = new CodeMethodInvokeExpression(targetObject, name);

            foreach (var item in node.Arguments)
            {
                var r = Visit(item);
                if (r is CodeExpression e)
                    call.Parameters.Add(e);
                else
                {
                    LocalDebug.Stop();
                }
            }

            return call;

        }

        protected object VisitConstant(ConstantExpression node)
        {

            if (node.Value == null)
                return node.ToPrimitive();

            if (node.Value is string)
                return node.ToPrimitive();

            if (node.Value.GetType().IsEnum)
            {
                var e = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(node.Type.ToRefType(_usings)), node.Value.ToString());
                return e;
            }

            if (node.Value.GetType().IsValueType)
                return node.ToPrimitive();

            if (!_fields.TryGetValue(node.Value, out CodeMemberField field))
                _fields.Add(node.Value, (field = new CodeMemberField(node.Type.ToRefType(_usings), $"srv_{this._fields.Count}") { Attributes = MemberAttributes.Private }));

            return new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name);

        }

        private object VisitConvert(UnaryExpression e)
        {
            var o = (CodeExpression)Visit(e.Operand);

            if (e.Type.IsAssignableFrom(e.Operand.Type))
                return o;

            return new CodeCastExpression(e.Type.ToRefType(_usings), o);
        }

        private object VisitAssign(BinaryExpression e)
        {
            var left = Visit(e.Left) as CodeExpression;
            var right = Visit(e.Right) as CodeExpression;

            if (left == null || right == null)
                LocalDebug.Stop();

            return left.AssignFrom(right);

        }

        private object VisitTypeIs(TypeBinaryExpression node)
        {
            var left = (CodeExpression)Visit(node.Expression);
            var right = new CodeTypeOfExpression(node.TypeOperand.ToRefType(_usings));
            return new CodeBinaryOperatorExpression(new CodeMethodInvokeExpression(left, "GetType"), CodeBinaryOperatorType.IdentityEquality, right);
        }

        protected object VisitNew(NewExpression node)
        {
            var result = new CodeObjectCreateExpression(node.Type.ToRefType(_usings));
            foreach (var item in node.Arguments)
                result.Parameters.Add((CodeExpression)Visit(item));
            return result;
        }

        protected CodeArrayCreateExpression VisitNewArray(NewArrayExpression node)
        {
            var result = new CodeArrayCreateExpression(node.Type.ToRefType(_usings));

            //Append(node.Type.Name);
            foreach (var item in node.Expressions)
            {
                var e = (CodeExpression)Visit(item);
                result.Initializers.Add(e);
            }

            return result;
        }

        protected object VisitConditional(ConditionalExpression node)
        {

            var test = Visit(node.Test);
            var condition = new CodeConditionStatement((CodeExpression)test);

            if (node.IfTrue is BlockExpression btrue)
                condition.TrueStatements.Add(VisitBlock(btrue));

            else if (node.IfTrue is DefaultExpression dtrue && dtrue.Type == typeof(void))
            {

            }
            else
            {
                var r = Visit(node.IfTrue);
                if (r != null && r is CodeObject c)
                    condition.TrueStatements.AddItem(c);
                else
                {
                    LocalDebug.Stop();
                }
            }


            if (node.IfFalse is BlockExpression bfalse)
                condition.FalseStatements.Add(VisitBlock(bfalse));

            else if (node.IfFalse is DefaultExpression dfalse && dfalse.Type == typeof(void))
            {

            }
            else
            {
                var r = Visit(node.IfFalse);
                if (r != null && r is CodeObject c)
                    condition.FalseStatements.AddItem(c);

                else
                {
                    LocalDebug.Stop();
                }
            }

            return condition;

        }

        protected object VisitLoop(LoopExpression node)
        {

            var loop = new CodeIterationStatement()
            {
                //IncrementStatement = new CodeExpressionStatement(new CodePrimitiveExpression(null)),
                //InitStatement = new CodeExpressionStatement(new CodePrimitiveExpression(null)),
            };

            if (node.Body is BlockExpression body)
                loop.Statements.Add(VisitBlock(body));

            if (node.Body is ConditionalExpression conditional)
            {

                loop.TestExpression = (CodeExpression)Visit(conditional.Test);

                if (conditional.IfTrue is BlockExpression body2)
                    loop.Statements.Add(VisitBlock(body2));

                else
                {
                    LocalDebug.Stop();
                    var r = Visit(conditional.IfTrue);
                    if (r != null)
                    {

                    }
                }
            }
            else
            {
                LocalDebug.Stop();
                var r = Visit(node.Body);
                if (r != null)
                {

                }
            }

            //AppendLabel(node.BreakLabel);

            return loop;
        }

        protected object VisitMember(MemberExpression node)
        {

            var targetObject = (CodeExpression)Visit(node.Expression);

            if (node.Member is PropertyInfo)
                return new CodePropertyReferenceExpression(targetObject, node.Member.Name);

            return new CodeFieldReferenceExpression(targetObject, node.Member.Name);
        }

        protected object VisitIndex(IndexExpression node)
        {

            var targetObject = (CodeExpression)Visit(node.Object);

            var result = new CodeIndexerExpression(targetObject);

            foreach (var item in node.Arguments)
                result.Indices.Add((CodeExpression)Visit(item));

            return result;
        }




        protected object VisitGoto(GotoExpression node)
        {
            LocalDebug.Stop();
            //Append(node.Target.Name);
            return node;
        }

        protected object VisitTypeBinary(TypeBinaryExpression node)
        {
            LocalDebug.Stop();
            Visit(node.Expression);
            //Append(node.Type);
            return node;
        }

        protected object VisitDebugInfo(DebugInfoExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitDefault(DefaultExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitDynamic(DynamicExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected ElementInit VisitElementInit(ElementInit node)
        {
            LocalDebug.Stop();
            return VisitElementInit(node);
        }

        protected object VisitExtension(Expression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitInvocation(InvocationExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitLabel(LabelExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitListInit(ListInitExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitMemberInit(MemberInitExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {
            LocalDebug.Stop();
            return VisitMemberMemberBinding(node);
        }

        protected object VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitSwitch(SwitchExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitSwitchCase(SwitchCase node)
        {
            LocalDebug.Stop();
            return node;
        }

        protected object VisitTry(TryExpression node)
        {
            LocalDebug.Stop();
            return Visit(node);
        }

        protected object VisitCatchBlock(CatchBlock node)
        {
            LocalDebug.Stop();
            return node;
        }

        protected object VisitLabelTarget(LabelTarget node)
        {
            return node;
        }




        private readonly CodeNamespace _namespaceRoot;
        private readonly string _methodname;
        private readonly CodeTypeDeclaration _typeRoot;
        private readonly HashSet<string> _usings;
        private readonly bool _withDebug;

        private Dictionary<object, string> _variables = new Dictionary<object, string>();

        private CodeMemberMethod _methodRoot;
        private Dictionary<object, CodeMemberField> _fields;
        private CodeStatement _last;

    }

}
