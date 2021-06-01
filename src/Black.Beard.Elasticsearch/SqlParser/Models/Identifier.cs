using Bb.Elastic.Runtimes;
using System;
using System.Text;

namespace Bb.Elastic.SqlParser.Models
{

    public class Identifier : AstBase
    {

        public Identifier(Locator position) : base(position)
        {

        }

        public string Text { get; set; }
        public IdentifierKindEnum Kind { get; set; }

        public bool Quoted { get; set; }
        public bool WithParenthesis { get; set; }

        public Identifier TargetLeft { get; set; }
        public Identifier TargetRight
        {
            get => _targetRight;
            set
            {
                _targetRight = value;
                value.TargetLeft = this;
            }
        }

        public Identifier TargetLast
        {
            get
            {
                if (TargetRight != null)
                    return TargetRight.TargetLast;
                return this;
            }
        }

        public bool IsKeywork { get; set; }
        public bool Wildcard { get; set; }

        public bool IsComposite => TargetRight != null;

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitIdentifier(this);
        }

        public Identifier GetServerName { get => this.GetName(IdentifierKindEnum.ServerReference); }
        public Identifier GetTableName { get => this.GetName(IdentifierKindEnum.TableReference); }
        public Identifier GetColumnName { get => this.GetName(IdentifierKindEnum.ColumnReference); }
        public Identifier GetfunctionName { get => this.GetName(IdentifierKindEnum.FunctionReference); }


        private Identifier GetName(IdentifierKindEnum kind)
        {
            if (this.Kind == kind)
                return this;

            if (this.TargetRight != null)
                return this.TargetRight.GetName(kind);

            return null;

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(100);
            ToString(sb);
            return sb.ToString();
        }

        private void ToString(StringBuilder sb)
        {
            sb.Append(this.Text);
            if (this.TargetRight != null)
            {
                sb.Append(".");
                TargetRight.ToString(sb);
            }
        }


        private Identifier _targetRight;
    }

    public enum IdentifierKindEnum
    {
        Undefined,
        ServerReference,
        TableReference,
        ColumnReference,
        FunctionReference,
    }




}
