using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode.Day_Four
{
    class GiantSquid
    {
        public List<LotteryBoard> LotteryBoards { get; set; }
        string filepath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Input\4\4.txt");
        string[] DataInput;
        string[] LotteryNumbers;
        List<int> WinningBoardScores; //This list will hold the answer to both Part one and Part two
        public GiantSquid()
        {
            DataInput = File.ReadAllLines(filepath);
            LotteryBoards = new List<LotteryBoard>();
            WinningBoardScores = new List<int>();

        }
        public void PartOne()
        {
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < DataInput.Length; i++)
            {
                if (DataInput[i].Contains(','))
                {
                    LotteryNumbers = DataInput[i].Split(',');
                }

                if (LotteryBoards.Count() == 98)
                {
                    Console.WriteLine("t");
                }

                if (DataInput[i].Contains(' ') && DataInput[i - 1] == "")
                {
                    index1 = i;
                }
                if (DataInput[i].Contains(' ') && i + 1 >= DataInput.Length)
                {
                    index2 = DataInput.Length;
                }
                else if (DataInput[i].Contains(' ') && DataInput[i + 1] == "")
                {
                    index2 = i + 1;
                }

                if (index1 != 0 && index2 != 0)
                {
                    string[] boardrow;
                    string[,] tempboard = new string[5, 5];
                    int count = 0;
                    for (int j = index1; j < index2; j++)
                    {

                        boardrow = DataInput[j].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        for (int l = 0; l < tempboard.GetLength(1); l++)
                        {
                            tempboard[count, l] = boardrow[l];
                        }
                        count++;

                    }
                    LotteryBoards.Add(new LotteryBoard(tempboard));
                    index1 = 0;
                    index2 = 0;
                }
            }
        }

       
        public void PartOneGame()
        {
            for (int i = 0; i < LotteryNumbers.Length; i++)
            {
                foreach (var LotteryBoard in LotteryBoards)
                {
                    if (!LotteryBoard.Bingo)
                    {
                        LotteryBoard.FillLotteryBoard(LotteryNumbers[i]);
                    }
                   
                    if (LotteryBoard.CorrectLotteryBoard())
                    {
                        WinningBoardScores.Add(LotteryBoard.WinningBoardCalculation(LotteryNumbers[i]));

                    }
                }
            }
        }
    }

    class LotteryBoard
    {
        string[,] Board;
        string[,] CorrectionBoard;
        public bool Bingo { get; set; }
        public LotteryBoard(string[,] lotteryboard)
        {
            Bingo = false;
            Board = lotteryboard;
            CorrectionBoard = new string[5, 5];
        }

        public void FillLotteryBoard(string LotteryNumber)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (LotteryNumber.Equals(Board[i, j]))
                    {
                        CorrectionBoard[i, j] = Board[i, j];
                    }
                }
            }
        }

        public bool CorrectLotteryBoard()
        {
            bool result = false;
            for (int i = 0; i < CorrectionBoard.GetLength(0); i++)
            {
                int CorrectCount = 0;
                for (int j = 0; j < CorrectionBoard.GetLength(1); j++)
                {
                    if (!this.Bingo)
                    {
                        if (CorrectionBoard[i, j] != null)
                        {
                            CorrectCount++;
                        }
                        if (CorrectionBoard[i, j] == null)
                        {
                            CorrectCount = 0;
                        }
                        if (CorrectCount == 4)
                        {
                            Bingo = true;
                            result = true;
                        }
                    }
                   
                }
            }
            return result;
        }

        public int WinningBoardCalculation(string LastNumber)
        {
            int sum = 0;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] != CorrectionBoard[i, j])
                    {
                        sum += Convert.ToInt32(Board[i, j]);
                    }
                }

            }
            return sum * Convert.ToInt32(LastNumber);
        }
    }
}
