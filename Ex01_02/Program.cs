using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            CreateDiamond();
        }

        public static void CreateDiamond()
        {
            int diamondSize = 9;
            int upperPartStarStartIndex = 1;
            int lowerPartStarStartIndex = 2;
            int upperPartSpaceStartIndex = diamondSize / 2 + 1;
            int lowerPartSpaceStartIndex = 1;

            BuildUpperPartOfDiamond(diamondSize, upperPartStarStartIndex, upperPartSpaceStartIndex);
            BuildLowerPartOfDiamond(diamondSize, lowerPartStarStartIndex, lowerPartSpaceStartIndex);
        }

        public static void BuildUpperPartOfDiamond(int i_NumberOfRows, int i_CurrentRow, int i_CurrentRowSpaceStartIndex)
        {
            int startIndexInRow = 0;
            int rowIndexIncreaseSize = 2;
            int spaceIndexIncreaseSize = -1;
            int starIndexIncreaseSize = 1;

            if (i_CurrentRow > i_NumberOfRows)
            {
                return;
            }

            AddSpaceToCurrentRow(i_NumberOfRows, i_CurrentRowSpaceStartIndex, spaceIndexIncreaseSize);
            PrintStarsInCurrentRow(startIndexInRow, i_CurrentRow, starIndexIncreaseSize);
            Console.WriteLine(Environment.NewLine);
            BuildUpperPartOfDiamond(i_NumberOfRows, i_CurrentRow + rowIndexIncreaseSize, i_CurrentRowSpaceStartIndex + 1);
        }

        public static void BuildLowerPartOfDiamond(int i_NumberOfRows, int i_CurrentRow, int i_CurrentRowSpaceStartIndex)
        {
            int startIndexInRow = 0;
            int rowIndexIncreaseSize = 2;
            int sizeOfIncreaeIndexAddSpace = 1;
            int starIndexIncreaseSize = -1;

            if (i_CurrentRow > i_NumberOfRows)
            {
                return;
            }

            AddSpaceToCurrentRow(startIndexInRow, i_CurrentRowSpaceStartIndex, sizeOfIncreaeIndexAddSpace);
            PrintStarsInCurrentRow(i_NumberOfRows, i_CurrentRow, starIndexIncreaseSize);
            Console.WriteLine(Environment.NewLine);
            BuildLowerPartOfDiamond(i_NumberOfRows, i_CurrentRow + rowIndexIncreaseSize, i_CurrentRowSpaceStartIndex + 1);
        }

        public static void PrintStarsInCurrentRow(int i_CurrentIndex, int i_FinalIndex, int i_IndexIncreaseSize)
        {
            if(i_CurrentIndex == i_FinalIndex)
            {
                return;
            }

            Console.Write("*");
            PrintStarsInCurrentRow(i_CurrentIndex + i_IndexIncreaseSize, i_FinalIndex, i_IndexIncreaseSize);
        }

        public static void AddSpaceToCurrentRow(int i_CurrentIndex, int i_FinalIndex, int i_IndexIncreaseSize)
        {
            if(i_CurrentIndex == i_FinalIndex)
            {
                return;
            }

            Console.Write(" ");
            AddSpaceToCurrentRow(i_CurrentIndex + i_IndexIncreaseSize, i_FinalIndex, i_IndexIncreaseSize);
        }
    }
}