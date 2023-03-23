using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorApi.Business.Services;
using CalculatorApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    /// <summary>
    /// Calculator controller class.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// Calculator service interface. 
        /// </summary>
        private readonly ICalculatorService calculatorService;

        /// <summary>
        /// Logger service interface.
        /// </summary>
        private readonly ILogger<CalculatorController> logger;

        /// <summary>
        /// Calculator controller constructor.
        /// </summary>
        /// <param name="calculatorService"></param>
        /// <param name="logger"></param>
        public CalculatorController(ICalculatorService calculatorService,
                                    ILogger<CalculatorController> logger)
        {
            this.calculatorService = calculatorService;
            this.logger = logger;
        }

        /// <summary>
        /// Add operands controller.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result</returns>
        [HttpPost("add")]
        public ActionResult<CalculatorResponse> Add(CalculatorRequest request)
        {
            logger.LogInformation("Received add request: {@request}", request);

            var validator = new CalculatorRequestValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var result = calculatorService.Add(request.LeftOperand, request.RightOperand);

            var response = new CalculatorResponse { Result = result };

            logger.LogInformation("Sending add response: {@response}", response);

            return Ok(request.LeftOperand + request.RightOperand);
        }

        /// <summary>
        /// Subtract two operands.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result</returns>
        [HttpPost("subtract")]
        public ActionResult<CalculatorResponse> Subtract(CalculatorRequest request)
        {
            logger.LogInformation("Received subtract request: {@request}", request);

            var validator = new CalculatorRequestValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var result = calculatorService.Subtract(request.LeftOperand, request.RightOperand);

            var response = new CalculatorResponse { Result = result };

            logger.LogInformation("Sending subtract response: {@response}", response);

            return Ok(response);
        }

        /// <summary>
        /// Multiply two operands.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result</returns>
        [HttpPost("multiply")]
        public ActionResult<CalculatorResponse> Multiply(CalculatorRequest request)
        {
            logger.LogInformation("Received multiply request: {@request}", request);

            var validator = new CalculatorRequestValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var result = calculatorService.Multiply(request.LeftOperand, request.RightOperand);

            var response = new CalculatorResponse { Result = result };

            logger.LogInformation("Sending multiply response: {@response}", response);

            return Ok(response);
        }

        /// <summary>
        /// Divide two operands.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result</returns>
        [HttpPost("divide")]
        public ActionResult<CalculatorResponse> Divide(CalculatorRequest request)
        {
            logger.LogInformation("Received divide request: {@request}", request);

            var validator = new CalculatorRequestValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            try
            {
                var result = calculatorService.Divide(request.LeftOperand, request.RightOperand);

                var response = new CalculatorResponse { Result = result };

                logger.LogInformation("Sending divide response: {@response}", response);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(CalculatorRequest.RightOperand), ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
