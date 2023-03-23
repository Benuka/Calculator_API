using System;
using FluentValidation;

namespace CalculatorApi.Model
{
    /// <summary>
    /// Calculator request validator.
    /// </summary>
	public class CalculatorRequestValidator : AbstractValidator<CalculatorRequest>
    {
        /// <summary>
        /// Calculator request validator constructor.
        /// </summary>
        public CalculatorRequestValidator()
        {
            RuleFor(x => x.LeftOperand).NotNull();
            RuleFor(x => x.RightOperand).NotNull();
        }
    }
}

