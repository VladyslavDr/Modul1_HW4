using System;

namespace Task
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var res = int.TryParse(Console.ReadLine(), out var size);

            if (res is true && size > 0)
            {
                var array = GetArrayWithRandomElements(new int[size]);

                Console.WriteLine("your array: ");
                ShowArray(array);

                SplitAtOddAndEven(array, out var arrayOfEvenNumbers, out var arrayOfOddNumbers);

                Console.WriteLine("array of even numbers:");
                ShowArray(arrayOfEvenNumbers);
                Console.WriteLine("array of odd numbers:");
                ShowArray(arrayOfOddNumbers);

                var stringEven = string.Join(" ", GetArrayLetters(arrayOfEvenNumbers, out var numberUpperCaseLetterInStringEven));
                var stringOdd = string.Join(" ", GetArrayLetters(arrayOfOddNumbers, out var numberUpperCaseLetterInStringOdd));

                Console.WriteLine($"string even: {stringEven}");
                Console.WriteLine($"string odd: {stringOdd}");

                if (numberUpperCaseLetterInStringEven > numberUpperCaseLetterInStringOdd)
                {
                    Console.WriteLine("there are more uppercase letters in the even array");
                }
                else if (numberUpperCaseLetterInStringEven < numberUpperCaseLetterInStringOdd)
                {
                    Console.WriteLine("there are more uppercase letters in the odd array");
                }
                else
                {
                    Console.WriteLine("both arrays have the same number of capital letters");
                }
            }
            else
            {
                Console.WriteLine("Error! The size of the array must be N{0}!");
            }
        }

        public static char[] GetArrayLetters(int[] arrayNambers, out int counter)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var letters = "aeidhj";
            counter = 0;

            var arrayLetters = new char[arrayNambers.Length];

            for (int index = 0; index < arrayNambers.Length; index++)
            {
                arrayLetters[index] = alphabet[arrayNambers[index] - 1];

                if (IsThisLetterOnTheList(arrayLetters[index], letters))
                {
                    arrayLetters[index] = char.ToUpper(arrayLetters[index]);
                    counter++;
                }
            }

            return arrayLetters;
        }

        public static bool IsThisLetterOnTheList(char l, string letters)
        {
            foreach (var letter in letters)
            {
                if (l.Equals(letter))
                {
                    return true;
                }
            }

            return false;
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