namespace Bb.JPaths.Expressions;

internal interface IUnaryLogicalOperator : IExpressionOperator
{
	bool Evaluate(bool value);
}