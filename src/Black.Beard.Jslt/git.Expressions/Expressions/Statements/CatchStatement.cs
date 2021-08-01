using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    public class CatchStatement : Statement
    {

        public CatchStatement()
            : base()
        {
            this.Body = new SourceCode();
        }

        public SourceCode Body 
        {
            get
            {
                if (_body == null)
                    Body = new SourceCode();

                return _body;
            }
            set
            {
                if (this.ParentIsNull)
                    _body.SetParent(this.GetParent());

                _body = value;
            }
        }

        SourceCode _body;

        public Type TypeToCatch { get; set; }


        public ParameterExpression Parameter 
        {
            get
            {
                if (_parameter == null)
                    _parameter = Body.AddVar(TypeToCatch);

                return _parameter;

            }
            set
            {
                _parameter = value;
            }
        }

        public override Expression GetExpression(HashSet<string> variableParent)
        {
            return Body.GetExpression(new HashSet<string>(variableParent));
        }

        internal override void SetParent(SourceCode sourceCodes)
        {
            _body.SetParent(sourceCodes);
        }

        private ParameterExpression _parameter;

    }

}
