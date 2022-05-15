namespace lesson2Task2
{
    class Program
    {
        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var nums = new List<int>() { 10, 5, 1, 15, 17, 0 }; // числа которые будем искать в массиве "array"

            foreach (int num in nums)
            {
                if (BinarySearch(array, num) != -1) Console.WriteLine($"Число {num} найдено под индексом {BinarySearch(array, num)}!");
                else Console.WriteLine($"Число {num} не найдено!");
            }

            // Асимптотическая сложность функции бинарного поиска BinarySearch - логарифмическая O(Log n)
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}