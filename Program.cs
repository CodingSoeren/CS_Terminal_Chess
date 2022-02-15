using System;

namespace Chess
{
    class Program
    {
        public static Field[,] Fields = new Field[8,8];

        static void Main(string[] args)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Fields[x, y] = new Field();
                }
            }

            StartGame();
            while (true)
            {
                DisplayState();
                Turn();
            }
        }

        static void StartGame()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (x == 0 && y == 3)
                    {
                        Fields[x, y].PieceOnField = Pieces.K;
                        Fields[x, y].PieceOnFieldColor = Colors.Blue;
                    }

                    if (x == 0 && y == 4)
                    {
                        Fields[x, y].PieceOnField = Pieces.Q;
                        Fields[x, y].PieceOnFieldColor = Colors.Blue;
                    }
                }
            }
        }

        static void DisplayState()
        {
            for(int y = 0; y < 8; y++)
            {
                for(int x = 0; x < 8; x++)
                {
                    Console.Write($"[{Fields[x, y].PieceOnField}]");
                }
                Console.WriteLine("");
            }
        }

        static void Turn()
        {
            Console.WriteLine("\nType Piece X that you want to move");
            string xin = Console.ReadLine();

            Console.Clear();
            DisplayState();

            Console.WriteLine("\nType Piece Y that you want to move");
            string yin = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"You want to move [{xin}|{yin}] ? [Y/n]");
            string tmp = Console.ReadLine();

            if (tmp == "n") return;
            if (tmp == "Y") ;
            else
            {
                Console.WriteLine("False Answer");
                System.Threading.Thread.Sleep(250);
                Turn();
                return;
            }

            Console.Clear();

            Console.WriteLine("Where do you want to move the piece X?");
            string toX = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Where do you want to move the piece Y?");
            string toY = Console.ReadLine();

            Console.WriteLine($"[{xin}|{yin}] -> [{toX}|{toY}]? [Y/n]");
            tmp = Console.ReadLine();

            if (tmp == "n") return;
            if (tmp == "Y") ;
            else
            {
                Console.WriteLine("False Answer");
                System.Threading.Thread.Sleep(250);
                Turn();
                return;
            }

            try
            {
                Move(int.Parse(xin), int.Parse(yin), int.Parse(toX), int.Parse(toY));
            }
            catch
            {
                Environment.Exit(69420);
            }
        }

        static void Move(int x, int y, int Tox, int Toy)
        {
            if (Fields[x, y].PieceOnField != Pieces.N)
            {
                Pieces TempPiece = Fields[x, y].PieceOnField;
                Colors TempColor = Fields[x, y].PieceOnFieldColor;

                Fields[x, y].PieceOnField = Pieces.N;
                Fields[x, y].PieceOnFieldColor = Colors.None;

                Fields[Tox, Toy].PieceOnField = TempPiece;
                Fields[Tox, Toy].PieceOnFieldColor = TempColor;
            }
        }
    }

    public class Field
    {
        public Pieces PieceOnField = Pieces.N;
        public Colors PieceOnFieldColor = Colors.None;
    }

    public enum Pieces
    {
        N = 0, //Horse
        P = 1, //Pawn
        R = 2, //Rock
        H = 3, //Horse
        B = 4, //Bishop
        Q = 5, //Queen
        K = 6  //King
    }

    public enum Colors
    {
        None = 0,
        Blue = 1,
        Red = 2
    }
}
