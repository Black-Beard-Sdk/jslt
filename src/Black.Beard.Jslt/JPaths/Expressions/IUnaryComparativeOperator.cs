namespace Bb.JPaths.Expressions;

internal interface IUnaryComparativeOperator : IExpressionOperator
{
	bool Evaluate(PathValue? value);
}