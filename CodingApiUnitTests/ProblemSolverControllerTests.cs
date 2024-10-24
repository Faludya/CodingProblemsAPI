using CodingProblemsAPI.Controllers;
using CodingProblemsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CodingApiUnitTests
{
    public class ProblemSolverControllerTests
    {
        private readonly Mock<IInputValidationService> _mockInputValidationService;
        private readonly Mock<IProblemSolverService> _mockProblemSolverService;
        private readonly ProblemSolverController _controller;

        public ProblemSolverControllerTests()
        {
            _mockInputValidationService = new Mock<IInputValidationService>();
            _mockProblemSolverService = new Mock<IProblemSolverService>();
            _controller = new ProblemSolverController(_mockProblemSolverService.Object, _mockInputValidationService.Object);
        }

        [Theory]
        [InlineData("{}[]", "Balanced")] 
        [InlineData("([)]", "Not balanced")]
        public void SolveBalancedBrackets_ReturnsOkResult(string brackets, string expected)
        {
            // Arrange
            _mockInputValidationService.Setup(v => v.IsBalancedBracketInputValid(brackets)).Returns(string.Empty);
            _mockProblemSolverService.Setup(s => s.SolveBalancedBrackets(brackets)).Returns(expected);

            // Act
            var result = _controller.SolveBalancedBrackets(brackets);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }

        [Theory]
        [InlineData("(abc)", "Input contains invalid characters.")]
        [InlineData("", "Input cannot be empty.")]
        public void SolveBalancedBrackets_ReturnsBadRequest(string brackets, string expectedErrorMessage)
        {
            // Arrange
            _mockInputValidationService.Setup(v => v.IsBalancedBracketInputValid(brackets)).Returns(expectedErrorMessage);

            // Act
            var result = _controller.SolveBalancedBrackets(brackets);

            // Assert
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal(expectedErrorMessage, badRequestResult.Value);
        }

        [Theory]
        [InlineData(new int[] { 2, 2, 1 }, 1)]
        [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
        [InlineData(new int[] { 1 }, 1)]
        public void SolveSingleNumber_ReturnsOkResult(int[] array, int expected)
        {
            // Arrange
            _mockInputValidationService.Setup(v => v.IsSingleNumberInputValid(array)).Returns(string.Empty);
            _mockProblemSolverService.Setup(s => s.SolveSingleNumbers(array)).Returns(expected);

            // Act
            var result = _controller.SolveSingleNumber(array);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }

        [Theory]
        [InlineData(new int[] { }, -1, "Input cannot be empty. Please enter a valid array.")]
        [InlineData(new int[] { 2, 2, 4, 4 }, -1, "Input cannot be empty. Please enter a valid array.")]
        public void SolveSingleNumber_ReturnsBadRequest(int[] array, int expectedError, string expectedErrorMessage)
        {
            // Arrange
            _mockInputValidationService.Setup(v => v.IsSingleNumberInputValid(array)).Returns(expectedErrorMessage);
            _mockProblemSolverService.Setup(s => s.SolveSingleNumbers(array)).Returns(expectedError);

            // Act
            var result = _controller.SolveSingleNumber(array);

            // Assert
            var okResult = result.Result as BadRequestObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(400, okResult.StatusCode);
            Assert.Equal(expectedErrorMessage, okResult.Value);
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 0 })]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 2, 1 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] { 1, 0 })]
        public void SolveTwoSum_ReturnsOkResult(int[] array, int target, int[] expected)
        {
            // Arrange
            _mockInputValidationService.Setup(v => v.IsTwoSumInputValid(array, target)).Returns(string.Empty);
            _mockProblemSolverService.Setup(s => s.SolveTwoSum(array, target)).Returns(expected);

            // Act
            var result = _controller.SolveTwoSum(array, target);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }

        [Theory]
        [InlineData(new int[] { }, 6, new int[] { -1, -1 }, "Input is not valid for the given problem.")]
        [InlineData(new int[] { 5, 0 }, 5, new int[] { -1, -1 }, "Input is not valid for the given problem.")]
        public void SolveTwoSum_ReturnsBadRequest(int[] array, int target, int[] expectedError, string errorMessage)
        {
            // Arrange
            _mockInputValidationService.Setup(v => v.IsTwoSumInputValid(array, target)).Returns(errorMessage);
            _mockProblemSolverService.Setup(s => s.SolveTwoSum(array, target)).Returns(expectedError);

            // Act
            var result = _controller.SolveTwoSum(array, target);

            // Assert
            var okResult = result.Result as BadRequestObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(400, okResult.StatusCode);
            Assert.Equal(errorMessage, okResult.Value);
        }
    }
}
