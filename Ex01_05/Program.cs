using System;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            RunNumbersStatistics();
        }

        public static void RunNumbersStatistics()
        {
            const int k_ValidUserInputLength = 9;
            string userInput = null;

            RequestUserInput(out userInput, k_ValidUserInputLength);
            FindLargestDigitInNumber(userInput);
            FindSmallestDigitInNumber(userInput);
            FindDigitsDivisibleByFour(userInput);
            FindDigitsGreaterThanUnitDigit(userInput);
        }

        public static void RequestUserInput(out string o_UserInput, int i_ValidUserInputLength)
        {
            string requestUserInputMsg = string.Format("Enter a positive number, the length must be {0} digits: ", i_ValidUserInputLength);

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
            int zeroCounter = 0;
            bool isUserInputValid = true;

            if (i_UserInput.Length != i_ValidUserInputLength)
            {
                isUserInputValid = false;
            }
            else
            {
                for (int i = 0; i < i_UserInput.Length; i++)
                {
                    if (i_UserInput[i] == '0')
                    {
                        zeroCounter++;
                    }
                    else if (char.IsDigit(i_UserInput[i]) == false)
                    {
                        isUserInputValid = false;
                        break;
                    }
                }

                if (zeroCounter == i_UserInput.Length)
                {
                    isUserInputValid = false;
                }
            }

            return isUserInputValid;
        }

        public static void FindLargestDigitInNumber(string i_UserInput)
        {
            int largestDigitSoFar = 0;
            int currentDigitInUserInput = 0;
            string largestDigitMsg = null;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                bool isValidDigit = int.TryParse(i_UserInput[i].ToString(), out currentDigitInUserInput);

                if (isValidDigit == true && largestDigitSoFar < currentDigitInUserInput)
                {
                    largestDigitSoFar = currentDigitInUserInput;
                }
            }

            largestDigitMsg = string.Format("The largest digit in {0} is: {1}.", i_UserInput, largestDigitSoFar);
            Console.WriteLine(largestDigitMsg);
        }

        public static void FindSmallestDigitInNumber(string i_UserInput)
        {
            int smallestDigitSoFar = 10;
            int currentDigitInUserInput = 0;
            string smallestDigitMsg = null;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                bool isValidDigit = int.TryParse(i_UserInput[i].ToString(), out currentDigitInUserInput);

                if (isValidDigit == true && smallestDigitSoFar > currentDigitInUserInput)
                {
                    smallestDigitSoFar = currentDigitInUserInput;
                }
            }
            
            smallestDigitMsg = string.Format("The smallest digit in {0} is: {1}.", i_UserInput, smallestDigitSoFar);
            Console.WriteLine(smallestDigitMsg);
        }

        public static void FindDigitsDivisibleByFour(string i_UserInput)
        {
            int numberOfDigitsDivisibleByFour = 0;
            int currentDigitInUserInput = 0;
            string numberOfDigitsDivisibleByFourSingularOrPluralMsg = null;
            string numberOfDigitsDivisibleByFourMsg = null;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                bool isValidDigit = int.TryParse(i_UserInput[i].ToString(), out currentDigitInUserInput);

                if (isValidDigit == true && currentDigitInUserInput % 4 == 0)
                {
                    numberOfDigitsDivisibleByFour++;
                }
            }

            numberOfDigitsDivisibleByFourSingularOrPluralMsg = numberOfDigitsDivisibleByFour == 1 ? "digit is" : "digits are";
            numberOfDigitsDivisibleByFourMsg = string.Format("{0} {1} divisible by 4.",
                numberOfDigitsDivisibleByFour, numberOfDigitsDivisibleByFourSingularOrPluralMsg);
            Console.WriteLine(numberOfDigitsDivisibleByFourMsg);
        }

        public static void FindDigitsGreaterThanUnitDigit(string i_UserInput)
        {
            int unitDigit = 0;
            int currentDigitInUserInput = 0;
            int numberOfDigitsGreaterThanUnitDigit = 0;
            bool isValidUnitDigit = int.TryParse(i_UserInput[i_UserInput.Length - 1].ToString(), out unitDigit);
            string numberOfDigitsGreaterThanUnitDigitSingularOrPluralMsg = null;
            string numberOfDigitsGreaterThanUnitDigitMsg = null;

            if (isValidUnitDigit == true)
            {
                for (int i = 0; i < i_UserInput.Length - 1; i++)
                {
                    bool isValidDigit = int.TryParse(i_UserInput[i].ToString(), out currentDigitInUserInput);

                    if (isValidDigit == true && currentDigitInUserInput > unitDigit)
                    {
                        numberOfDigitsGreaterThanUnitDigit++;
                    }
                }
            }

            numberOfDigitsGreaterThanUnitDigitSingularOrPluralMsg = numberOfDigitsGreaterThanUnitDigit == 1 ? "digit is" : "digits are";
            numberOfDigitsGreaterThanUnitDigitMsg = string.Format("{0} {1} greater than the unit digit.",
                numberOfDigitsGreaterThanUnitDigit, numberOfDigitsGreaterThanUnitDigitSingularOrPluralMsg);
            Console.WriteLine(numberOfDigitsGreaterThanUnitDigitMsg);
        }
    }
}
