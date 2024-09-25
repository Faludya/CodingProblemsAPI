namespace CodingProblemsAPI.Services
{
    public class InputValidationService : IInputValidationService
    {
        public (bool isValid, string message) IsBalancedBracketInputValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return (false, "Input cannot be empty. Please enter a valid string.");
            }

            HashSet<char> validChars = [ '(', ')', '[', ']', '{', '}' ];

            if (!input.All(validChars.Contains))
            {
                return (false, "Input contains invalid characters. Only '()', '{}', and '[]' are allowed.");
            }

            return (true, "Input is valid.");
        }

        public (bool isValid, string message) IsSingleNumberInputValid(int[] input)
        {
            if (input.Length == 0)
            {
                return (false, "Input cannot be empty. Please enter a valid array.");
            }

            if (input.Length == 2)
            {
                return (false, "Input is not valid for the given problem.");
            }

            return (true, "Input is valid.");
        }

        public (bool isValid, string message) IsTwoSumInputValid(int[] array, int target)
        {
            if (array.Length < 2)
            {
                return (false, "Input is not valid for the given problem.");
            }

            return (true, "Input is valid.");
        }
    }
}
