using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Expressions
{

    public class SourceGenerator : System.Linq.Expressions.ExpressionVisitor
    {

        private SourceGenerator(string[] usings)
        {
            this._usings = new HashSet<string>(usings);
            this._usings.Add("System");
            this._usings.Add("Diagnostics");

            foreach (var item in this._usings)
            {
                Append($"using {item}");
                CutLine();
            }
        }

        public static StringBuilder GetCode(Expression e, params string[] usings)
        {
            SourceGenerator s = new SourceGenerator(usings);
            s.IncrementIndentation();
            s.Visit(e);
            s.DecrementIndentation();
            return s.sb;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            CutLine();
            Append(node.ReturnType);
            AppendSpace();

            Append("MyMethod(");

            bool t = false;
            foreach (var item in node.Parameters)
            {
                if (t)
                    Append(Comma);
                Append(item.Type);
                Append(" ");
                Visit(item);
                t = true;
            }
            Append(")");
            CutLine();

            if (!(node.Body is BlockExpression))
            {
                Append("{");
                CutLine();
                IncrementIndentation();
            }

            Visit(node.Body);

            if (!(node.Body is BlockExpression))
            {
                DecrementIndentation();
                Append("}");
                CutLine();
            }

            return node;
        }

        protected override Expression VisitBlock(BlockExpression node)
        {

            Append("{");
            CutLine();
            IncrementIndentation();

            //foreach (var item in node.Variables)
            //{
            //    Append("Declare ");
            //    Visit(item);
            //    CutLine();
            //}
            //CutLine();

            foreach (var item in node.Expressions)
            {
                CutLine();
                Visit(item);
            }

            DecrementIndentation();
            CutLine();
            Append("}");
            CutLine();

            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {

            Visit(node.Left);

            switch (node.NodeType)
            {

                case ExpressionType.NotEqual:
                    Append(" != ");
                    break;
                case ExpressionType.Divide:
                    Append(" / ");
                    break;
                case ExpressionType.DivideAssign:
                    Append(" /= ");
                    break;
                case ExpressionType.Add:
                    Append(" + ");
                    break;
                case ExpressionType.AddAssign:
                    Append(" += ");
                    break;
                case ExpressionType.And:
                    Append(" & ");
                    break;
                case ExpressionType.AndAlso:
                    Append(" && ");
                    break;
                case ExpressionType.AndAssign:
                    Append(" &= ");
                    break;
                case ExpressionType.Assign:
                    Append(" = ");
                    break;
                case ExpressionType.Equal:
                    Append(" == ");
                    break;
                case ExpressionType.GreaterThan:
                    Append(" > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    Append(" >= ");
                    break;
                case ExpressionType.ExclusiveOr:
                    Append(" || ");
                    break;
                case ExpressionType.ExclusiveOrAssign:
                    break;
                case ExpressionType.LessThan:
                    Append(" < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    Append(" >= ");
                    break;
                case ExpressionType.LeftShift:
                    Append(" << ");
                    break;
                case ExpressionType.Coalesce:
                    Append(" ?? ");
                    break;
                case ExpressionType.Or:
                    break;
                case ExpressionType.OrAssign:
                    Append(" |= ");
                    break;
                case ExpressionType.OrElse:
                    break;
                case ExpressionType.Power:
                    Append(" ^ ");
                    break;
                case ExpressionType.PowerAssign:
                    Append(" ^= ");
                    break;
                case ExpressionType.PreDecrementAssign:
                    Append(" --");
                    break;
                case ExpressionType.PreIncrementAssign:
                    Append(" ++");
                    break;
                case ExpressionType.Subtract:
                    Append(" - ");
                    break;
                case ExpressionType.SubtractAssign:
                    Append(" -= ");
                    break;
                case ExpressionType.Multiply:
                    Append(" * ");
                    break;
                case ExpressionType.MultiplyAssign:
                    Append(" *= ");
                    break;
                case ExpressionType.Modulo:
                    Append(" % ");
                    break;
                case ExpressionType.ModuloAssign:
                    Append(" %= ");
                    break;
                case ExpressionType.RightShift:
                    Append(" >> ");
                    break;
                case ExpressionType.TypeIs:
                    Append(" is ");
                    break;
                case ExpressionType.TypeAs:
                    Append(" as ");
                    break;

                case ExpressionType.RightShiftAssign:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.PostDecrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.SubtractChecked:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.AddChecked:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.MultiplyAssignChecked:
                    LocalDebug.Stop();
                    break;

                case ExpressionType.ConvertChecked:
                case ExpressionType.DebugInfo:
                case ExpressionType.ArrayIndex:
                case ExpressionType.ArrayLength:
                case ExpressionType.Default:
                case ExpressionType.Dynamic:
                case ExpressionType.Extension:
                case ExpressionType.Goto:
                case ExpressionType.Index:
                case ExpressionType.Invoke:
                case ExpressionType.Label:
                case ExpressionType.Lambda:
                case ExpressionType.ListInit:
                case ExpressionType.MemberAccess:
                case ExpressionType.MemberInit:
                    LocalDebug.Stop();
                    break;

                default:
                    LocalDebug.Stop();
                    break;
            }

            Visit(node.Right);

            return node;
        }

        protected override Expression VisitNew(NewExpression node)
        {
            Append("new ");
            Append(node.Type);
            Append("(");
            bool t = false;
            foreach (var item in node.Arguments)
            {
                if (t)
                    Append(Comma);
                Visit(item);
                t = true;
            }
            Append(")");
            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            Append(node.Name ?? node.ToString());
            return node;
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {

            Append("if (");
            Visit(node.Test);
            Append(")");

            CutLine();

            if (!(node.IfTrue is BlockExpression))
            {
                Append("{");
                CutLine();
                IncrementIndentation();
            }

            Visit(node.IfTrue);

            if (!(node.IfTrue is BlockExpression))
            {
                DecrementIndentation();
                CutLine();
                Append("}");
                CutLine();
            }
            Append("else");

            if (!(node.IfFalse is BlockExpression))
            {
                IncrementIndentation();
            }

            CutLine();

            Visit(node.IfFalse);


            if (!(node.IfFalse is BlockExpression))
            {
                DecrementIndentation();
                CutLine();
            }

            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {

            if (node.Object == null)
                Append(node.Method.DeclaringType.Name);
            else
                Visit(node.Object);

            Append(".");
            Append(node.Method.Name);

            Append("(");
            bool t = false;
            foreach (var item in node.Arguments)
            {
                if (t)
                    Append(Comma);
                Visit(item);
                t = true;
            }
            Append(")");

            return node;

        }

        protected override Expression VisitConstant(ConstantExpression node)
        {

            if (node.Value is string)
                Append($"{Quote}{node.Value}{Quote}");

            else if (node.Value is char)
                Append($"'{node.Value}'");

            else
            {
                if (node.Value == null)
                    Append("null");
                else
                    Append(node.Value.ToString());
            }
            return node;

        }

        protected override Expression VisitLoop(LoopExpression node)
        {

            Append("Loop");
            CutLine();

            if (!(node.Body is BlockExpression))
            {
                Append("{");
                IncrementIndentation();
            }

            AppendLabel(node.ContinueLabel);

            Visit(node.Body);

            if (!(node.Body is BlockExpression))
            {
                DecrementIndentation();
                CutLine();
                Append("}");
            }

            CutLine();

            Append("Goto ");
            Append(node.ContinueLabel.Name);

            AppendLabel(node.BreakLabel);

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {

            Visit(node.Expression);
            Append(".");
            Append(node.Member.Name);

            return node;
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            Visit(node.Object);
            Append("[");

            bool t = false;
            foreach (var item in node.Arguments)
            {
                if (t)
                    Append(Comma);
                Visit(item);
                t = true;
            }

            Append("]");

            return node;
        }

        protected override Expression VisitGoto(GotoExpression node)
        {
            Append("Goto ");
            Append(node.Target.Name);
            return node;
        }


        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            Visit(node.Expression);
            Append(" is ");
            Append(node.Type);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {

                case ExpressionType.Increment:
                    Visit(node.Operand);
                    Append("++ ");
                    break;
                case ExpressionType.Decrement:
                    Visit(node.Operand);
                    Append("-- ");
                    break;

                case ExpressionType.Convert:
                    Append("((");
                    Append(node.Type);
                    Append(")");
                    Visit(node.Operand);
                    Append(")");
                    break;

                case ExpressionType.Not:
                    Append("!");
                    Visit(node.Operand);
                    break;

                case ExpressionType.IsTrue:
                    Visit(node.Operand);
                    Append(" == true");
                    break;

                case ExpressionType.IsFalse:
                    Visit(node.Operand);
                    Append(" == false");
                    break;

                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.UnaryPlus:
                    LocalDebug.Stop();
                    break;

                default:
                    break;

            }

            return node;
        }

        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {
            LocalDebug.Stop();
            return base.VisitDebugInfo(node);
        }

        protected override Expression VisitDefault(DefaultExpression node)
        {
            Append("default(");
            Append(node.Type);
            Append(")");

            return base.VisitDefault(node);
        }

        protected override Expression VisitDynamic(DynamicExpression node)
        {
            LocalDebug.Stop();
            return base.VisitDynamic(node);
        }

        protected override ElementInit VisitElementInit(ElementInit node)
        {
            LocalDebug.Stop();
            return base.VisitElementInit(node);
        }

        protected override Expression VisitExtension(Expression node)
        {
            LocalDebug.Stop();
            return base.VisitExtension(node);
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            LocalDebug.Stop();
            return base.VisitInvocation(node);
        }

        protected override Expression VisitLabel(LabelExpression node)
        {
            LocalDebug.Stop();
            return base.VisitLabel(node);
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            LocalDebug.Stop();
            return base.VisitListInit(node);
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            LocalDebug.Stop();
            return base.VisitMemberAssignment(node);
        }

        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {
            LocalDebug.Stop();
            return base.VisitMemberBinding(node);
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            LocalDebug.Stop();
            return base.VisitMemberInit(node);
        }
        protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
        {
            LocalDebug.Stop();
            return base.VisitMemberListBinding(node);
        }

        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {
            LocalDebug.Stop();
            return base.VisitMemberMemberBinding(node);
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {

            Append("new ");
            Append(node.Type.Name);
            Append("{ ");
            string comma = string.Empty;
            foreach (var item in node.Expressions)
            {
                Append(comma);
                Visit(item);
                comma = Comma;
            }
            Append(" }");

            return node;
        }

        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            LocalDebug.Stop();
            return base.VisitRuntimeVariables(node);
        }

        protected override Expression VisitSwitch(SwitchExpression node)
        {
            LocalDebug.Stop();
            return base.VisitSwitch(node);
        }

        protected override SwitchCase VisitSwitchCase(SwitchCase node)
        {
            LocalDebug.Stop();
            return base.VisitSwitchCase(node);
        }



        protected override Expression VisitTry(TryExpression node)
        {
            LocalDebug.Stop();
            return base.VisitTry(node);
        }

        protected override CatchBlock VisitCatchBlock(CatchBlock node)
        {
            LocalDebug.Stop();
            return base.VisitCatchBlock(node);
        }

        #region Write

        private void AppendSpace()
        {
            //Debug.Write(" ");
            sb.Append(" ");
        }

        private void Append(Type type)
        {

            var t = type.FullName;

            foreach (var item in this._usings)
                if (t.StartsWith(item))
                {
                    t = t.Substring(item.Length + 1);
                    break;
                }

            //Debug.Write(t);
            sb.Append(t);
        }

        private void Append(string txt)
        {
            //Debug.Write(txt);
            sb.Append(txt);
        }

        private void CutLine()
        {
            //Debug.WriteLine("");
            sb.AppendLine();
            for (int i = 0; i < _indentation; i++)
            {
                sb.Append('\t');
                //Debug.Write('\t');
            }
        }

        private void AppendLabel(LabelTarget label)
        {
            //Debug.WriteLine("");
            sb.AppendLine("");
            Append(label.Name);
            //Debug.Write(" : ");
            sb.Append(" : ");
            CutLine();
        }

        #endregion Write


        private void IncrementIndentation()
        {
            _indentation++;
        }
        private void DecrementIndentation()
        {
            _indentation--;
        }

        private int _indentation;
        private StringBuilder sb = new StringBuilder(10 * 1024);
        private readonly HashSet<string> _usings;


        public const char Quote = '"';
        public const string Comma = ", ";

    }

}
