using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson3Task1
{
    class Program
    {
        static void Main()
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
        }
    }

    // вариант для ссылочного типа
    public class PointClass
    {
        public float X;
        public float Y;
    }

    // вариант для типа float
    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }

    // вариант для типа double
    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }


    public class BechmarkClass
    {
        public static readonly int size = 1000; // размер массива данных
        public static PointClass[] pointClassArray = new PointClass[size + 1];
        public static PointStructFloat[] pointStructFloatArray = new PointStructFloat[size + 1];
        public static PointStructDouble[] pointStructDoubleArray = new PointStructDouble[size + 1];
        public BechmarkClass()
        {
            Random rnd = new Random();
            // заполняем массив случайными данными
            for (int i = 0; i <= size; i++)
            {
                pointStructFloatArray[i].X = (float)rnd.NextDouble();
                pointStructFloatArray[i].Y = (float)rnd.NextDouble();
                pointStructDoubleArray[i].X = rnd.NextDouble();
                pointStructDoubleArray[i].Y = rnd.NextDouble();
                pointClassArray[i] = new PointClass
                {
                    X = pointStructFloatArray[i].X,
                    Y = pointStructFloatArray[i].Y
                };
            }
        }

        public static float PointDistance(ref PointClass pointOne, ref PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceShort(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        #region Benchmark

        [Benchmark(Description = "1. Обычный метод расчёта дистанции со ссылочным типом(PointClass — координаты типа float)")]
        public void TestPointDistance()
        {
            for (int i = 0; i < size; i++)
            {
                PointDistance(ref pointClassArray[i], ref pointClassArray[i + 1]);
            }
        }
        [Benchmark(Description = "2. Обычный метод расчёта дистанции со значимым типом(PointStruct — координаты типа float)")]
        public void TestPointDistanceFloat()
        {
            for (int i = 0; i < size; i++)
            {
                PointDistanceFloat(pointStructFloatArray[i], pointStructFloatArray[i + 1]);
            }
        }
        [Benchmark(Description = "3. Обычный метод расчёта дистанции со значимым типом(PointStruct — координаты типа double)")]
        public void TestPointDistanceDouble()
        {
            for (int i = 0; i < size; i++)
            {
                PointDistanceDouble(pointStructDoubleArray[i], pointStructDoubleArray[i + 1]);
            }
        }
        [Benchmark(Description = "4. Метод расчёта дистанции без квадратного корня со значимым типом(PointStruct — координаты типа float)")]
        public void TestPointDistanceShort()
        {
            for (int i = 0; i < size; i++)
            {
                PointDistanceShort(pointStructFloatArray[i], pointStructFloatArray[i + 1]);
            }
        }

        #endregion
    }
}

// ┌───────────────────────────────────────────────────────────────────────────────────────────────────────────┬───────────┬────────────┬────────────┐
// │ Method                                                                                                    │ Mean      │ Error      │ StdDev     │
// ├───────────────────────────────────────────────────────────────────────────────────────────────────────────┼───────────┼────────────┼────────────┤
// │ '1. Обычный метод расчёта дистанции со ссылочным типом(PointClass - координаты типа float)'               │ 3.850 us  │ 0.0117 us  │ 0.0109 us  │
// │ '2. Обычный метод расчёта дистанции со значимым типом(PointStruct - координаты типа float)'               │ 1.105 us  │ 0.0042 us  │ 0.0033 us  │
// │ '3. Обычный метод расчёта дистанции со значимым типом(PointStruct - координаты типа double)'              │ 1.375 us  │ 0.0060 us  │ 0.0053 us  │
// │ '4. Метод расчёта дистанции без квадратного корня со значимым типом(PointStruct - координаты типа float)' │ 1.102 us  │ 0.0020 us  │ 0.0017 us  │
// └───────────────────────────────────────────────────────────────────────────────────────────────────────────┴───────────┴────────────┴────────────┘