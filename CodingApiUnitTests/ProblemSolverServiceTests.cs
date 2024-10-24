using CodingProblemsAPI.Services;

namespace CodingApiUnitTests
{
    public class ProblemSolverServiceTests
    {
        private readonly ProblemSolverService _service;

        public ProblemSolverServiceTests()
        {
            _service = new ProblemSolverService();
        }

        #region Two sum problem
        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 0 })]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 2, 1 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] {1, 0 })]
        public void SolveTwoSum_ReturnsCorrectIndexes(int[] array, int target, int[] expected)
        {
            var result = _service.SolveTwoSum(array, target);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 10, new int[] { -1, -1 })] 
        [InlineData(new int[] { }, 6, new int[] { -1, -1 })]          
        [InlineData(new int[] { 5 }, 5, new int[] { -1, -1 })] 
        public void SolveTwoSum_NoSolution_ReturnsNegativeIndexes(int[] array, int target, int[] expected)
        {
            var result = _service.SolveTwoSum(array, target);

            Assert.Equal(expected, result);
        }
        #endregion

        #region Single numbers problem
        [Theory]
        [InlineData(new int[] { 2, 2, 1 }, 1)]
        [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
        [InlineData(new int[] { 1 }, 1)]
        public void SolveSingleNumbers_ReturnsCorrectNumber(int[] array, int expected)
        {
            var result = _service.SolveSingleNumbers(array);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { }, -1)] 
        [InlineData(new int[] { 2, 2, 4, 4 }, -1)] 
        public void SolveSingleNumbers_NoSingleNumber_ReturnsErrorValue(int[] array, int expected)
        {
            var result = _service.SolveSingleNumbers(array);

            Assert.Equal(expected, result);
        }
        #endregion

        #region Balanced brackets problem
        [Theory]
        [InlineData("()", "Balanced")]
        [InlineData("()[]{}", "Balanced")]
        [InlineData("(]", "Not balanced")]
        [InlineData("([)]", "Not balanced")]
        [InlineData("{[]}", "Balanced")]
        public void SolveBalancedBrackets_ReturnsCorrectResult(string brackets, string expected)
        {
            var result = _service.SolveBalancedBrackets(brackets);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123", "Not balanced")]
        [InlineData("abc", "Not balanced")]
        public void SolveBalancedBrackets_InvalidInput(string brackets, string expected)
        {
            var result = _service.SolveBalancedBrackets(brackets);

            Assert.Equal(expected, result);
        }
        #endregion
    }
}
