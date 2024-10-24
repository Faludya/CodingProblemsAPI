namespace CodingProblemsAPI.Services
{
    //TODO: add 2,3 more problems 
    //TODO: add unit tests
    //TODO: how to add auth to API
    //think about new small project
    public class ProblemSolverService : IProblemSolverService
    {
        //Time complexity: ~O(n*3) = O(n), space complexity: O(n)
        public string SolveBalancedBrackets(string brackets)
        {
            var bracketsPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            var stack = new Stack<char>();

            for (int i = 0; i < brackets.Length; i++)
            {
                if (bracketsPairs.ContainsKey(brackets[i]))
                {
                    stack.Push(brackets[i]);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return "Not balanced";
                }

                if (bracketsPairs.ContainsValue(brackets[i]) && brackets[i] == bracketsPairs[stack.First()])
                {
                    stack.Pop();
                }
                else
                    return "Not balanced";

            }

            return stack.Count == 0 ? "Balanced" : "Not balanced";
        }

        //Time complexity: ~O(n), space complexity: O(n)
        public int SolveSingleNumbers(int[] array)
        {
            var numSet = new HashSet<int>();
            foreach (var n in array)
            {
                if (numSet.Contains(n))
                {
                    numSet.Remove(n);
                }
                else
                {
                    numSet.Add(n);
                }
            }

            if (numSet.Count == 1)
            {
                return numSet.First();
            }

            else return -1;
        }

        //adding edge cases in catch is very slow on runtime
        /* example: on licensing checks for opening balances, there was a code to verify if the response is ok
         * if the response was not ok it would go throw an error 
         * however that would miss the licensing check so someone who shouldn't have access would have it
         */
        public int[] SolveTwoSum(int[] array, int target)
        {
            int[] indexes = [-1, -1];
            //(complement value, index)
            var hashMap = new Dictionary<int, int>();
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var complement = target - array[i];

                    if (hashMap.TryGetValue(complement, out int index))
                    {
                        indexes[0] = i;
                        indexes[1] = index;

                        return indexes;
                    }

                    // check for duplicates in the array, ex: [3, 3]
                    if (!hashMap.ContainsKey(array[i]))
                    {
                        hashMap.Add(array[i], i);
                    }
                    else if (array[i] + array[i - 1] == target)
                    {
                        indexes[0] = i - 1;
                        indexes[1] = i;
                        return indexes;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return indexes;
        }
    }
}
