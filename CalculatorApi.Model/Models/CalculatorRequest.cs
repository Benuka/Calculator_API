namespace CalculatorApi.Model
{
    /// <summary>
    /// Calculator request model.
    /// </summary>
	public class CalculatorRequest
	{
        /// <summary>
        /// Left operand.
        /// </summary>
        public double LeftOperand { get; set; } = double.NaN;

        /// <summary>
        /// Right operand.
        /// </summary>
        public double RightOperand { get; set; } = double.NaN;
    }
}

