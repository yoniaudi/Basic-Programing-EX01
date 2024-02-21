using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            CreateAdvancedDiamond();
        }

        public static void CreateAdvancedDiamond()
        {
            RequestDiamondSizeFromUser(out int diamondSize);

            int upperPartStarStartIndex = 1;
            int lowerPartStarStartIndex = 2;
            int upperPartSpaceStartIndex = diamondSize / 2 + 1;
            int lowerPartSpaceStartIndex = 1;

            Ex01_02.Program.BuildUpperPartOfDiamond(diamondSize, upperPartStarStartIndex, upperPartSpaceStartIndex);
            Ex01_02.Program.BuildLowerPartOfDiamond(diamondSize, lowerPartStarStartIndex, lowerPartSpaceStartIndex);
        }

        public static void RequestDiamondSizeFromUser(out int o_UserInputDiamondSize)
        {
            string userInputDiamondSizeStr = null;

            Console.Write("Enter diamond size: ");
            userInputDiamondSizeStr = Console.ReadLine();
            int.TryParse(userInputDiamondSizeStr, out o_UserInputDiamondSize);

            while(o_UserInputDiamondSize <= 0)
            {
                Console.WriteLine("Error: Input is not supported.");
                Console.Write("Enter a new valid positive number: ");

                userInputDiamondSizeStr = Console.ReadLine();
                int.TryParse(userInputDiamondSizeStr, out o_UserInputDiamondSize);
            }

            if (o_UserInputDiamondSize % 2 == 0)
            {
                o_UserInputDiamondSize++;
            }
        }
    }
}