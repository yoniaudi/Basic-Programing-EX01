using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        private const int k_NumberOfInputsFromUser = 3;
        private const int k_BinaryNumberLength = 9;
        private static int[] m_UserDecimalNumbersAscending = new int[k_NumberOfInputsFromUser];
        private static string[] m_UserBinaryNumbersInput = new string[k_NumberOfInputsFromUser];
        
        public static void Main()
        {
            RunBinarySeries();
        }

        public static void RunBinarySeries()
        {
            ReadBinaryNumbersFromUser();
            PrintDecimalNumbersInAscendingOrder();
            PrintAverageOfZeroAndOneDigits();
            CountPowerOfTwoNumbers();
            CountNumbersWithAscendingDigits();
            PrintSmallestAndBiggestNumbers();
        }

        public static void ReadBinaryNumbersFromUser()
        {
            string userInputInstructionsMsg = string.Format("Enter {0} positive binary numbers, the length of each number should be exactly {1} digits: ",
                k_NumberOfInputsFromUser, k_BinaryNumberLength);
            
            Console.WriteLine(userInputInstructionsMsg);

            for (int i = 0;  i < k_NumberOfInputsFromUser; i++)
            {
                string userInput = null;
                string userInputMsg = string.Format("Enter number {0}: ", i + 1);

                Console.WriteLine(userInputMsg);
                userInput = Console.ReadLine();

                while (CheckIfBinaryInputIsValid(userInput) == false)
                {
                    string errorMsg = string.Format("Invalid input! Enter number {0} again.{1}The number has to be positive and the length of each number should be exactly {2} digits: ",
                        i + 1, Environment.NewLine, k_BinaryNumberLength);
                    
                    Console.WriteLine(errorMsg);
                    userInput = Console.ReadLine();
                }

                m_UserBinaryNumbersInput[i] = userInput;
            }
        }

        public static bool CheckIfBinaryInputIsValid(string i_UserString)
        {
            int zeroCounter = 0;
            bool isBinaryInputIsValid = true;

            if (i_UserString.Length != k_BinaryNumberLength)
            {
                isBinaryInputIsValid = false;
            }
            else
            {
                for (int i = 0; i < i_UserString.Length; i++)
                {
                    if (i_UserString[i] == '0')
                    {
                        zeroCounter++;
                    }
                    else if (i_UserString[i] != '0' && i_UserString[i] != '1')
                    {
                        isBinaryInputIsValid = false;
                        break;
                    }
                }

                if (zeroCounter == i_UserString.Length)
                {
                    isBinaryInputIsValid = false;
                }
            }

            return isBinaryInputIsValid;
        }

        public static void PrintDecimalNumbersInAscendingOrder()
        {
            StringBuilder numberValuesMsg = new StringBuilder();

            SortUserInputAsDecimalNumbersAscending();
            Console.Write("The numbers in ascending order: ");

            for (int i = 0; i < k_NumberOfInputsFromUser; i++)
            {
                numberValuesMsg.Append(m_UserDecimalNumbersAscending[i]);
                numberValuesMsg.Append(", ");
            }

            if (numberValuesMsg.Length > 0)
            {
                numberValuesMsg.Length -= 2;
                numberValuesMsg.Append(".");
            }

            Console.WriteLine(numberValuesMsg);
        }

        public static void SortUserInputAsDecimalNumbersAscending()
        {
            for (int i = 0; i < k_NumberOfInputsFromUser; i++)
            {
                m_UserDecimalNumbersAscending[i] = ConvertBinaryToDecimal(m_UserBinaryNumbersInput[i]);
            }

            Array.Sort(m_UserDecimalNumbersAscending);
        }

        public static int ConvertBinaryToDecimal(string i_BinaryStr)
        {
            int decimalNumber = 0;

            for (int i = i_BinaryStr.Length - 1; i >= 0; i--)
            {
                if (i_BinaryStr[i] == '1')
                {
                    decimalNumber += Convert.ToInt32(Math.Pow(2, i_BinaryStr.Length - 1 - i));
                }
            }

            return decimalNumber;
        }

        public static void PrintAverageOfZeroAndOneDigits()
        {
            int zeroCounter = 0;
            int oneCounter = 0;
            float zeroAverage = 0f;
            float oneAverage = 0f;
            string averageOfZeroAndOneMsg = null;

            for (int i = 0; i < k_NumberOfInputsFromUser; i++)
            {
                string binaryNumber = m_UserBinaryNumbersInput[i];

                for (int j = 0; j < k_BinaryNumberLength; j++)
                {
                    if (binaryNumber[j] == '0')
                    {
                        zeroCounter++;
                    }
                    else
                    {
                        oneCounter++;
                    }
                }
            }
            
            zeroAverage = zeroCounter / (float)k_NumberOfInputsFromUser;
            oneAverage = oneCounter / (float)k_NumberOfInputsFromUser;

            averageOfZeroAndOneMsg = string.Format("The average of 0 digits in each input number is: {0:f2}.{1}The average of 1 digits in each input number is: {2:f2}.",
                zeroAverage, Environment.NewLine, oneAverage);
            Console.WriteLine(averageOfZeroAndOneMsg);
        }

        public static void CountPowerOfTwoNumbers()
        {
            int powerOfTwoCounter = 0;
            string powerOfTwoSingularOrPluralMsg = null;
            string powerOfTwoNumbersMsg = null;

            for (int i = 0; i < k_NumberOfInputsFromUser; i++)
            {
                powerOfTwoCounter += IsANumberIsAPowerOfTwo(m_UserBinaryNumbersInput[i]) ? 1 : 0;
            }

            powerOfTwoSingularOrPluralMsg = powerOfTwoCounter == 1 ? "number is a power of two." : "numbers are powers of two.";
            powerOfTwoNumbersMsg = string.Format("{0} {1}", powerOfTwoCounter, powerOfTwoSingularOrPluralMsg);
            Console.WriteLine(powerOfTwoNumbersMsg);
        }

        public static bool IsANumberIsAPowerOfTwo(string i_Number)
        {
            int singleDigitCounter = 0;
            bool isANumberIsAPowerOfTwo = true;

            for (int i = 0; i < k_BinaryNumberLength; i++)
            {
                if (i_Number[i] == '1')
                {
                    singleDigitCounter++;
                    
                    if (singleDigitCounter > 1)
                    {
                        isANumberIsAPowerOfTwo = false;
                        break;
                    }
                }
            }

            return isANumberIsAPowerOfTwo;
        }

        public static void CountNumbersWithAscendingDigits()
        {
            int numberOfNumbersWithAscendingDigits = 0;
            string ascendingOrderSingularOrPluralMsg = null;
            string ascendingOrderMsg = null;

            for (int i = 0; i < k_NumberOfInputsFromUser; i++)
            {
                if (HasAscendingDigits(m_UserDecimalNumbersAscending[i]) == true)
                {
                    numberOfNumbersWithAscendingDigits++;
                }
            }

            ascendingOrderSingularOrPluralMsg = numberOfNumbersWithAscendingDigits == 1 ? "number is" : "numbers are";
            ascendingOrderMsg = string.Format("{0} {1} built from ascending order digits.",
                numberOfNumbersWithAscendingDigits, ascendingOrderSingularOrPluralMsg);
            Console.WriteLine(ascendingOrderMsg);
        }

        public static bool HasAscendingDigits(int i_Number)
        {
            bool ascendingOrderNumberStatus = true;

            while (i_Number >= 10)
            {
                if (i_Number % 10 <= (i_Number / 10) % 10)
                {
                    ascendingOrderNumberStatus = false;
                    break;
                }

                i_Number /= 10;
            }

            return ascendingOrderNumberStatus;
        }

        public static void PrintSmallestAndBiggestNumbers()
        {
            string smallestAndBiggestNumbersMsg = string.Format("The smallest number is {0} and the biggest number is {1}.",
                m_UserDecimalNumbersAscending[0], m_UserDecimalNumbersAscending[m_UserDecimalNumbersAscending.Length - 1]);

            Console.WriteLine(smallestAndBiggestNumbersMsg);
        }
    }
}