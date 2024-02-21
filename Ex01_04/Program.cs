using System;
using System.Linq;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            StringAnalysis();
        }

        public static void StringAnalysis()
        {
            const int k_ValidUserInputLength = 8;
            bool isUserInputContainsOnlyDigits = false;
            string userInput = null;

            RequestUserInput(out userInput, k_ValidUserInputLength);
            PrintPolindrom(userInput);

            isUserInputContainsOnlyDigits = userInput.All(char.IsDigit);

            if (isUserInputContainsOnlyDigits == true)
            {
                CheckIfStringIsDivisibleByFive(userInput);
            }
            else
            {
                CheckNumberOfLowercaseLetters(userInput);
            }
        }

        public static void RequestUserInput(out string o_UserInput, int i_ValidUserInputLength)
        {
            string requestUserInputMsg = string.Format("Rules:{0}1. The string's length must be exactly {1} characters long.{0}2. The string must contain either letters only or digits only, but not both.{0}Enter a string and press enter: ",
                Environment.NewLine, i_ValidUserInputLength);

            Console.Write(requestUserInputMsg);
            o_UserInput = Console.ReadLine();

            while (IsUserInputValid(o_UserInput, i_ValidUserInputLength) == false)
            {
                Console.WriteLine("ERROR: invalid input.");
                Console.Write(requestUserInputMsg);

                o_UserInput = Console.ReadLine();
            }
        }

        public static bool IsUserInputValid(string i_UserInput, int i_ValidUserInputLength)
        {
            bool containsOnlyDigits = i_UserInput.All(char.IsDigit);
            bool containsOnlyLetters = i_UserInput.All(char.IsLetter);

            return (i_UserInput.Length == i_ValidUserInputLength) && (containsOnlyDigits || containsOnlyLetters);
        }

        public static bool IsPolindrom(string i_UserInput, int i_StartIndex, int i_EndIndex)
        {
            bool isPolindrom = false;

            if (i_UserInput[i_StartIndex] != i_UserInput[i_EndIndex])
            {
                isPolindrom = false;
            }
            else
            {
                if (i_StartIndex == i_EndIndex || i_StartIndex == i_EndIndex - 1)
                {
                    isPolindrom = true;
                }
                else
                {
                    isPolindrom = IsPolindrom(i_UserInput, i_StartIndex + 1, i_EndIndex - 1);
                }
            }

            return isPolindrom;
        }

        public static void PrintPolindrom(string i_UserInput)
        {
            int palindromeStartIndex = 0;
            int palindromeEndIndex = i_UserInput.Length - 1;
            bool isPolindrom = IsPolindrom(i_UserInput, palindromeStartIndex, palindromeEndIndex);
            string isPolindromIndicateMsg = string.Format("The string {0} {1} a polindrom.", i_UserInput, isPolindrom ? "is" : "is not");

            Console.WriteLine(isPolindromIndicateMsg);
        }

        public static void CheckIfStringIsDivisibleByFive(string i_UserInput)
        {
            char rightMostDigit = i_UserInput[i_UserInput.Length - 1];
            string isDivisibleByFiveIndicatorMsg = (rightMostDigit == '0' || rightMostDigit == '5') ? "is" : "is not";
            string isDivisbleByFiveMsg = string.Format("The string {0} {1} divisible by 5.", i_UserInput, isDivisibleByFiveIndicatorMsg);

            Console.WriteLine(isDivisbleByFiveMsg);
        }

        public static void CheckNumberOfLowercaseLetters(string i_UserInput)
        {
            int numberOfLowercaseLetters = 0;
            string numberOfLowercaseLettersMsg = null;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (char.IsLower(i_UserInput[i]) == true)
                {
                    numberOfLowercaseLetters++;
                }
            }

            numberOfLowercaseLettersMsg = string.Format("The number of lowercase letters in {0} is {1}.", i_UserInput, numberOfLowercaseLetters);
            Console.WriteLine(numberOfLowercaseLettersMsg);
        }
    }
}