namespace Bb.JPaths.Expressions;

internal interface IBinaryValueOperator : IExpressionOperator
{
	PathValue? Evaluate(PathValue? left, PathValue? right);
}

internal interface IExpressionOperator
{
	int Precedence { get; }
}