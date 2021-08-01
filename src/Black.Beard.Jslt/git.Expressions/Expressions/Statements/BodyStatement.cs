namespace Bb.Expressions.Statements
{
    public abstract class BodyStatement : Statement
    {


        public BodyStatement()
        {

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
                    _body.SetParent(GetParent());

                _body = value;
            }
        }

        internal override void SetParent(SourceCode sourceCodes)
        {
            _body.SetParent(sourceCodes);
        }

        private SourceCode _body;
    }


}
