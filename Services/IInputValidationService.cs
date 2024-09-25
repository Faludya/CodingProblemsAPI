namespace CodingProblemsAPI.Services
{
    public interface IInputValidationService
    {
        public (bool isValid, string message) IsBalancedBracketInputValid(string input);
        public (bool isValid, string message) IsSingleNumberInputValid(int[] input);
        public (bool isValid, string message) IsTwoSumInputValid(int[] array, int target);
    }
}
