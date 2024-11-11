namespace Bb.JPaths.Expressions;

internal interface IBinaryComparativeOperator : IExpressionOperator
{
	bool Evaluate(PathValue? left, PathValue? right);
}