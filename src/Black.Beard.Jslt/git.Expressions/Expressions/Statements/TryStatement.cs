using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    public class TryStatement : BodyStatement
    {


        public TryStatement()
        {
            this._catchs = new List<CatchStatement>();
        }
        // 

        public CatchStatement Catch()
        {
            return Catch(typeof(Exception));
        }

        public CatchStatement Catch(Type self)
        {

            var result = new CatchStatement()
            {
                TypeToCatch = self,
            };

            this._catchs.Add(result);

            if (this.ParentIsNull)
                result.SetParent(this.GetParent());

            return result;

        }

        public IEnumerable<CatchStatement> Catchs { get => _catchs; }

        public SourceCode Finally
        {
            get
            {

                if (_finally == null)
                    Finally = new SourceCode();

                return _finally;
            }
            set
            {
                if (this.ParentIsNull)
                    _finally.SetParent(this.GetParent());

                _finally = value;
            }

        }



        public override Expression GetExpression(HashSet<string> variableParent)
        {

            List<CatchBlock> _catchs = new List<CatchBlock>();
            Expression resultExpression;
            Expression expressionFinaly = null;

            Expression expressionTry = Body.GetExpression(new HashSet<string>(variableParent));

            foreach (CatchStatement @catch in Catchs)
            {
                CatchBlock c;
                if (@catch.Parameter != null)
                {
                    variableParent.Add(@catch.Parameter.Name);

                    @catch.Body.AddVarIfNotExists(@catch.Parameter);
                    var body = @catch.GetExpression(variableParent);
                    c = Expression.Catch(@catch.Parameter, body);

                    variableParent.Remove(@catch.Parameter.Name);

                }
                else
                {
                    var body = @catch.GetExpression(variableParent);
                    c = Expression.Catch(@catch.TypeToCatch, body);
                }
                _catchs.Add(c);
            }

            if (_finally != null)
                    expressionFinaly = _finally.GetExpression(new HashSet<string>(variableParent));


            if (expressionFinaly != null)
            {
                if (_catchs.Count > 0)
                    resultExpression = Expression.TryCatchFinally(expressionTry, expressionFinaly, _catchs.ToArray());
                else
                    resultExpression =Expression.TryFinally(expressionTry, expressionFinaly);
            }
            else
                resultExpression = Expression.TryCatch(expressionTry, _catchs.ToArray());

            if (resultExpression.CanReduce)
                resultExpression = resultExpression.Reduce();

            return resultExpression;

        }

        internal override void SetParent(SourceCode sourceCodes)
        {
            base.SetParent(sourceCodes);
            _finally?.SetParent(sourceCodes);
            foreach (var item in Catchs)
                item.SetParent(sourceCodes);
        }

        private SourceCode _finally;
        private readonly List<CatchStatement> _catchs;
    }

}
