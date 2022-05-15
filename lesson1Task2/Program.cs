namespace lesson1Task2
{
    class Program
    {
        static void Main()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6 };
            var strangeSum = StrangeSum(inputArray);
        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; // O(1)
                        if (j != 0)
                        {
                            y = k / j; // O(1)
                        }
                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }
            return sum; // O(1)
        }
    }
}

// Асимптотическая сложность функции: O(1) * O(N) * O(N) * O(N) * O(1) * O(1) * O(1) * O(1) = O(N^3)