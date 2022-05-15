namespace lesson1Task1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"На вход подаем -3, ожидаем \"Простое\": {IsPastNumber(-3)}");
            Console.WriteLine($"На вход подаем 3, ожидаем \"Простое\": {IsPastNumber(3)}");
            Console.WriteLine($"На вход подаем 5, ожидаем \"Простое\": {IsPastNumber(5)}");
            Console.WriteLine($"На вход подаем 13, ожидаем \"Простое\": {IsPastNumber(13)}");
            Console.WriteLine($"На вход подаем 15, ожидаем \"Не простое\": {IsPastNumber(15)}");
            Console.WriteLine($"На вход подаем 50, ожидаем \"Не простое\": {IsPastNumber(50)}");
        }
        public static string IsPastNumber(int number)
        {
            var d = 0;
            var i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return "Простое";
            }
            return "Не простое";
        }
    }
}