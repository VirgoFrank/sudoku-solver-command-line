using System;
using System.Linq;

namespace working_sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawBoard board = new DrawBoard();
            int row = 0;
            int col = 0;
            board.Draw(col,row);
            

            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        row--;
                        Console.Clear();
                        board.Draw(col, row);
                        break;
                    case ConsoleKey.DownArrow:
                        row++;
                        Console.Clear();
                        board.Draw(col, row);
                        break;
                    case ConsoleKey.LeftArrow:
                        col--;
                        Console.Clear();
                        board.Draw(col, row);
                        break;
                    case ConsoleKey.RightArrow:
                        col++;
                        Console.Clear();
                        board.Draw(col, row);
                        break;
                    case ConsoleKey.Enter:
                        int num = GetNumber();
                        if(num != 0 & board.check(col,row,num))
                        DrawBoard.board[row, col] = (int)num;
                        else
                        {
                            Console.Clear();
                            board.Draw(col, row);
                            Console.WriteLine("Invalid number");
                            break;
                        }
                        Console.Clear();
                        board.Draw(col, row);
                        break;
                    case ConsoleKey.Spacebar:
                        board.Solve();
                        Console.WriteLine("\n**************");
                        board.Draw(col, row);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Entry");
                        break;
                }
            }
            
        }
        static int GetNumber()
        {
            Console.WriteLine("Enter a number");
            string num = Console.ReadLine();
            if(num.Length > 1 | num.Any(x => char.IsLetter(x)))
            {
                return 0;
            }
           
            return Convert.ToInt32(num);
        }
    }
}
