namespace CodingProblemsAPI.Services
{
    public interface IInputValidationService
    {
        public string IsBalancedBracketInputValid(string input);
        public string IsSingleNumberInputValid(int[] input);
        public string IsTwoSumInputValid(int[] array, int target);
    }
}
