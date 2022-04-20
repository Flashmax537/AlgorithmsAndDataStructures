namespace lesson1Task3
{
    class Program
    {
        static void Main()
        {
            var errorMessage = "Ошибка: На вход должно подоваться число больше или равное 0!";

            var test1 = GetFibonaccibWithRecursion(-10) == -1 ? errorMessage : GetFibonaccibWithRecursion(-10).ToString();
            var test2 = GetFibonaccibWithRecursion(0) == -1 ? errorMessage : GetFibonaccibWithRecursion(0).ToString();
            var test3 = GetFibonaccibWithRecursion(3) == -1 ? errorMessage : GetFibonaccibWithRecursion(3).ToString();
            var test4 = GetFibonaccibWithRecursion(10) == -1 ? errorMessage : GetFibonaccibWithRecursion(10).ToString();

            var test5 = GetFibonacciWithOutRecursion(-10) == -1 ? errorMessage : GetFibonacciWithOutRecursion(-10).ToString();
            var test6 = GetFibonacciWithOutRecursion(0) == -1 ? errorMessage : GetFibonacciWithOutRecursion(0).ToString();
            var test7 = GetFibonacciWithOutRecursion(3) == -1 ? errorMessage : GetFibonacciWithOutRecursion(3).ToString();
            var test8 = GetFibonacciWithOutRecursion(10) == -1 ? errorMessage : GetFibonacciWithOutRecursion(10).ToString();

            Console.WriteLine("Числа фибоначчи с рекурсией:");
            Console.WriteLine($"На вход подаем -10, ожидаем ошибку: {test1}");
            Console.WriteLine($"На вход подаем 0, ожидаем 0: {test2}");
            Console.WriteLine($"На вход подаем 3, ожидаем 2: {test3}");
            Console.WriteLine($"На вход подаем 10, ожидаем 55: {test4}");

            Console.WriteLine("\nЧисла фибоначчи без рекурсии:");
            Console.WriteLine($"На вход подаем -10, ожидаем ошибку: {test5}");
            Console.WriteLine($"На вход подаем 0, ожидаем 0: {test6}");
            Console.WriteLine($"На вход подаем 3, ожидаем 2: {test7}");
            Console.WriteLine($"На вход подаем 10, ожидаем 55: {test8}");
        }

        /// <summary>
        /// Получение числа фибоначчи для заданного значения с рекурсией
        /// </summary>
        /// <param name="number">Значение</param>
        /// <returns></returns>
        public static int GetFibonaccibWithRecursion(int number)
        {
            if (number < 0) return -1; // код ошибки
            if (number == 0) return 0;
            if (number == 1) return 1;

            return GetFibonaccibWithRecursion(number - 1) + GetFibonaccibWithRecursion(number - 2);
        }

        /// <summary>
        /// Получение числа фибоначчи для заданного значения без рекурсии
        /// </summary>
        /// <param name="number">Значение</param>
        /// <returns></returns>
        public static int GetFibonacciWithOutRecursion(int number)
        {
            var result = 0;
            var lastNumber = 1; // последнее число
            var previousNumber = 0; // предыдущее число

            if (number < 0) return -1; // код ошибки
            if (number == 0) return 0;
            if (number == 1) return 1;

            for (int i = 2; i <= number; i++)
            {
                result = lastNumber + previousNumber;
                previousNumber = lastNumber;
                lastNumber = result;
            }
            return result;
        }
    }
}