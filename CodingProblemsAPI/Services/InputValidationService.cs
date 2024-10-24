namespace CodingProblemsAPI.Services
{
    public class InputValidationService : IInputValidationService
    {
        public string IsBalancedBracketInputValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Input cannot be empty. Please enter a valid string.";
            }

            HashSet<char> validChars = [ '(', ')', '[', ']', '{', '}' ];

            if (!input.All(validChars.Contains))
            {
                return "Input contains invalid characters. Only '()', '{}', and '[]' are allowed.";
            }

            return "";
        }

        public string IsSingleNumberInputValid(int[] input)
        {
            if (input.Length == 0)
            {
                return "Input cannot be empty. Please enter a valid array.";
            }

            if (input.Length == 2)
            {
                return "Input is not valid for the given problem.";
            }

            return "";
        }

        public string IsTwoSumInputValid(int[] array, int target)
        {
            if (array.Length < 2)
            {
                return "Input is not valid for the given problem.";
            }

            return "";
        }
    }
}
