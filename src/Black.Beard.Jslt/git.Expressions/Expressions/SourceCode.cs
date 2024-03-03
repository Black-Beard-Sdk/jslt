using Bb.Expressions.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expressions
{

    public partial class SourceCode : ICollection<Statement>
    {


        public SourceCode()
        {
            _variables = new Variables();
            _labels = new Labels();
        }


        public SourceCode Add(params Statement[] statements)
        {
            foreach (var statement in statements)
                Add(statement);

            return this;
        }


        internal Expression GetExpression(HashSet<string> variableParent)
        {
            Expression expression = null;

            if (this._statements.Count == 1)
                expression = this._statements[0].GetExpression(variableParent);
            else
                expression = GetBlock(variableParent);

            if (expression.CanReduce)
                expression = expression.Reduce();

            return expression;

        }

        public IEnumerable<ParameterExpression> Variables { get => this._variables.Items.Select(c => c.Instance); }

        public Statement LastStatement { get; private set; }

        public ParameterExpression LastVariable { get; private set; }

        private BlockExpression GetBlock(HashSet<string> variableParent)
        {

            ParameterExpression[] __variables = CleanVariables(variableParent);

            var __list = new List<Expression>(this._statements.Count + 10);
            foreach (Statement statement in this._statements)
                __list.Add(statement.GetExpression(variableParent));

            return Expression.Block(__variables, __list.ToArray());

        }

        internal void SetParent(SourceCode sourceCodes)
        {
            this._parent = sourceCodes;
            _variables.SetParent(sourceCodes._variables);
            _labels.SetParent(sourceCodes._labels);
        }

        public void Merge(SourceCode source)
        {

            this._variables.Merge(source._variables);
            this._labels.Merge(source._labels);


            foreach (var item in source._statements)
                this.Add(item);

        }

        protected ParameterExpression[] CleanVariables(HashSet<string> variableParent)
        {

            var v = this._variables.Items.ToList();
            foreach (var item in v)
                if (!(variableParent.Add(item.Name)))
                    this._variables.RemoveByName(item.Name);

            var __variables = this._variables.Items.Select(c => c.Instance).ToArray();

            return __variables;

        }



        public void Add(Statement statement)
        {
            statement.SetParent(this);
            _statements.Add(statement);
            this.LastStatement = statement;
        }

        public void Clear()
        {
            _statements.Clear();
        }

        public bool Contains(Statement item)
        {
            return _statements.Contains(item);
        }

        public void CopyTo(Statement[] array, int arrayIndex)
        {
            _statements.CopyTo(array, arrayIndex);
        }

        public bool Remove(Statement item)
        {
            return _statements.Remove(item);
        }

        public IEnumerator<Statement> GetEnumerator()
        {
            return _statements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _statements.GetEnumerator();
        }

        public int Count => _statements.Count;

        public bool IsReadOnly => false;


        public static implicit operator SourceCode(Expression expression)
        {
            var src = new SourceCode();
                src.Add(expression);
            return src;
        }

        public static implicit operator SourceCode(Expression[] expressions)
        {
            var src = new SourceCode();
            foreach (var item in expressions)
                src.Add(item);
            return src;
        }

        public static implicit operator SourceCode(List<Expression> expressions)
        {
            var src = new SourceCode();
            foreach (var item in expressions)
                src.Add(item);
            return src;
        }

        public static implicit operator SourceCode(Statement expression)
        {
            var src = new SourceCode();
            src.Add(expression);
            return src;
        }

        public static implicit operator SourceCode(Statement[] statements)
        {
            var src = new SourceCode();
            foreach (var item in statements)
                src.Add(item);
            return src;
        }

        public static implicit operator SourceCode(List<Statement> statements)
        {
            var src = new SourceCode();
            foreach (var item in statements)
                src.Add(item);
            return src;
        }


        protected Variables _variables;
        protected Labels _labels;
        private SourceCode _parent;
        private List<Statement> _statements = new List<Statement>();

    }

}
