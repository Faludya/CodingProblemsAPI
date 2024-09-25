namespace CodingProblemsAPI.Services
{
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

        public int[] SolveTwoSum(int[] array, int target)
        {
            int[] indexes = [-1, -1];
            //(complement value, index)
            var hashMap = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                var complement = target - array[i];

                try
                {
                    if (hashMap.TryGetValue(complement, out int index))
                    {
                        indexes[0] = i;
                        indexes[1] = index;

                        return indexes;
                    }
                    else
                        hashMap.Add(array[i], i);
                }
                catch (Exception ex)
                {
                    //in case the array contains duplicated values (ex: [3, 3, 4, 5], target = 6)
                    if (ex.Message.Contains("An item with the same key has already been added"))
                    {
                        if (array[i] + array[i - 1] == target)
                        {
                            indexes[0] = i - 1;
                            indexes[1] = i;

                            return indexes;
                        }
                    }
                }
            }

            return indexes;
        }
    }
}
