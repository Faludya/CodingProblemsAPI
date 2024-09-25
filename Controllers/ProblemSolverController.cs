using CodingProblemsAPI.Services;
using Microsoft.AspNetCore.Mvc;

//To investigate:
//Q1: Why is only 1 parameter allowed from body? -> should I switch to reading it as a json?
//Q2: What are the best approaches for try catch blocks? When should they be used?

namespace CodingProblemsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemSolverController : ControllerBase
    {
        private readonly IProblemSolverService _problemSolverService;
        private readonly IInputValidationService _inputValidationService;

        public ProblemSolverController(IProblemSolverService problemSolverService, IInputValidationService inputValidationService)
        {
            _problemSolverService = problemSolverService;
            _inputValidationService = inputValidationService;
        }

        [HttpGet("balancedbracket")]
        /// <summary>
        ///  Returns the solution for the Balanced Brackets problem
        /// </summary>
        /// <param name="brackets">eg: {}]</param>
        /// <returns>Balanced or Not balanced</returns>
        public ActionResult<string> SolveBalancedBrackets(string brackets)
        {
            var (isInputValid, message) = _inputValidationService.IsBalancedBracketInputValid(brackets);
            if (!isInputValid)
            {
                return BadRequest(message);
            }

            return Ok(_problemSolverService.SolveBalancedBrackets(brackets));
        }

        [HttpPost("singlenumber")]
        /// <summary>
        ///  Returns the solution for the Single Number problem
        /// </summary>
        /// <param name="array"></param>
        /// <returns>The number which appears only once in the array</returns>
        public ActionResult<int> SolveSingleNumber([FromBody] int[] array)
        {
            var (isInputValid, message) = _inputValidationService.IsSingleNumberInputValid(array);
            if (!isInputValid)
            {
                return BadRequest(message);
            }
            
            return Ok(_problemSolverService.SolveSingleNumbers(array));
        }

        [HttpPost("twosum")]
        /// <summary>
        ///  Returns the solution for the Two sum problem
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns>The pair of numbers which add up to the target</returns>
        public ActionResult<int> SolveTwoSum([FromBody] int[] array, int target)
        {
            var (isInputValid, message) = _inputValidationService.IsTwoSumInputValid(array, target);
            if (!isInputValid)
            {
                return BadRequest(message);
            }

            return Ok(_problemSolverService.SolveTwoSum(array, target));
        }
    }
}
