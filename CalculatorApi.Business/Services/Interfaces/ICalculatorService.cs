namespace CalculatorApi.Business.Services
{
    /// <summary>
    /// Calculate service interface.
    /// </summary>
	public interface ICalculatorService
	{
        /// <summary>
        /// Add two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        double Add(double leftOperand, double rightOperand);

        /// <summary>
        /// Subtract two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        double Subtract(double leftOperand, double rightOperand);

        /// <summary>
        /// Multiply two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        double Multiply(double leftOperand, double rightOperand);

        /// <summary>
        /// Divide two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        double Divide(double leftOperand, double rightOperand);
    }
}

