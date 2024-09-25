namespace CodingProblemsAPI.Services
{
    public interface IProblemSolverService
    {
        int SolveSingleNumbers(int[] array);
        string SolveBalancedBrackets(string brackets);
        int[] SolveTwoSum(int[] array, int target);
    }
}
