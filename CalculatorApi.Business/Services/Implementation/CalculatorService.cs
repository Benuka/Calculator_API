namespace CalculatorApi.Business.Services
{
    /// <summary>
    /// Calculator service.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        //// <summary>
        /// Add two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        public double Add(double leftOperand, double rightOperand)
        {
            return leftOperand + rightOperand;
        }

        /// <summary>
        /// Subtract two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        public double Subtract(double leftOperand, double rightOperand)
        {
            return leftOperand - rightOperand;
        }

        /// <summary>
        /// Multiply two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        public double Multiply(double leftOperand, double rightOperand)
        {
            return leftOperand * rightOperand;
        }

        /// <summary>
        /// Divide two operands.
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns>Result</returns>
        /// <exception cref="ArgumentException"></exception>
        public double Divide(double leftOperand, double rightOperand)
        {
            if (rightOperand == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return leftOperand / rightOperand;
        }
    }
}

