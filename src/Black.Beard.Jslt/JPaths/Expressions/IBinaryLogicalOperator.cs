namespace Bb.JPaths.Expressions;

internal interface IBinaryLogicalOperator : IExpressionOperator
{
	bool Evaluate(bool left, bool right);
}