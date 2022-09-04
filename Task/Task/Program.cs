﻿using System;

namespace Task
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            _ = int.TryParse(Console.ReadLine(), out var size);

            var array = GetArrayWithRandomElements(new int[size]);

            ShowArray(array);

            int[] arrayOfEvenNumbers;
            int[] arrayOfOddNumbers;

            SplitAtOddAndEven(array, out arrayOfEvenNumbers, out arrayOfOddNumbers);

            ShowArray(arrayOfEvenNumbers);
            ShowArray(arrayOfOddNumbers);
        }

        public static void SplitAtOddAndEven(int[] array, out int[] arrayOfEvenNumbers, out int[] arrayOfOddNumbers)
        {
            int numberEvenElements;
            int numberOddElements;

            GetNumberOfEvenAndOddElements(array, out numberEvenElements, out numberOddElements);

            arrayOfEvenNumbers = new int[numberEvenElements];
            arrayOfOddNumbers = new int[numberOddElements];

            int index1 = 0;
            int index2 = 0;

            foreach (var number in array)
            {
                if (number % 2 == 0)
                {
                    arrayOfEvenNumbers[index1++] = number;
                }
                else
                {
                    arrayOfOddNumbers[index2++] = number;
                }
            }
        }

        public static void ShowArray(int[] array)
        {
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }

        public static void GetNumberOfEvenAndOddElements(int[] array, out int even, out int odd)
        {
            even = 0;
            odd = 0;

            foreach (var number in array)
            {
                if (number % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }
        }

        public static int[] GetArrayWithRandomElements(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = new Random().Next(1, 27);
            }

            return array;
        }
    }
}
