using CalculatorApi.Model;
using FluentValidation;

namespace CalculatorApi.Model
{
    /// <summary>
    /// Calculator response validator.
    /// </summary>
	public class CalculatorResponseValidator : AbstractValidator<CalculatorResponse>
    {
        /// <summary>
        /// Calculator response validator constructor.
        /// </summary>
        public CalculatorResponseValidator()
        {
            RuleFor(x => x.Result).NotNull(); ;
        }
    }
}
