using System;

namespace Task
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            _ = int.TryParse(Console.ReadLine(), out var size);

            var arrayOfNumbers = GetArrayWithRandomElements(new int[size]);
        }

        public static int[] GetArrayWithRandomElements(int[] arrayOfNumbers)
        {
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                arrayOfNumbers[index] = new Random().Next(1, 27);
            }

            return arrayOfNumbers;
        }
    }
}
