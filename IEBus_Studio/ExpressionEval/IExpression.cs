using System;

namespace ExpressionEvaluation
{
    /// <summary>
    /// This interface is the base for all of the expression evaluation objects.
    /// </summary>
    public interface IExpression
    {
        string Expression { get; set; }
        object Evaluate();
    }
}
