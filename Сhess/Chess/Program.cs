namespace ConsoleApp1
{
    using System;

    public class Chess
    {
        public bool CanKingMove(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1;
        }

        public bool CanQueenMove(int x1, int y1, int x2, int y2)
        {
            return CanRookMove(x1, y1, x2, y2) || CanBishopMove(x1, y1, x2, y2);
        }

        public bool CanRookMove(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 || y1 == y2;
        }

        public bool CanBishopMove(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
        }

        public bool CanKnightMove(int x1, int y1, int x2, int y2)
        {
            return (Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1) ||
                   (Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2);
        }

        public bool CanPawnMove(int x1, int y1, int x2, int y2, bool isWhite)
        {
            if (isWhite)
            {
                return (x2 == x1 && y2 == y1 + 1) || (x1 == x2 && y1 == 1 && y2 == 3);
            }
            else
            {
                return (x2 == x1 && y2 == y1 - 1) || (x1 == x2 && y1 == 6 && y2 == 4);
            }
        }

        public bool CanPieceMove(string piece, int x1, int y1, int x2, int y2)
        {
            switch (piece.ToLower())
            {
                case "king":
                    return CanKingMove(x1, y1, x2, y2);
                case "queen":
                    return CanQueenMove(x1, y1, x2, y2);
                case "rook":
                    return CanRookMove(x1, y1, x2, y2);
                case "bishop":
                    return CanBishopMove(x1, y1, x2, y2);
                case "knight":
                    return CanKnightMove(x1, y1, x2, y2);
                case "pawn":
                    return CanPawnMove(x1, y1, x2, y2, true); 
                default:
                    Console.WriteLine("Недопустимое значение");
                    return false;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Chess chess = new Chess();

            Console.WriteLine("Выберите фигру за которую будете делать ход (Например: King, Queen, Rook, Bishop, Knight, Pawn: ");
            string selectedPiece = Console.ReadLine();

            Console.WriteLine("Напишите первые координаты куда нужно сделать ход (x1 y1):");
            string[] startPos = Console.ReadLine().Split(' ');
            int x1 = int.Parse(startPos[0]);
            int y1 = int.Parse(startPos[1]);

            Console.WriteLine("Напишите вторые координаты куда нужно сделать ход (x2 y2): ");
            string[] destPos = Console.ReadLine().Split(' ');
            int x2 = int.Parse(destPos[0]);
            int y2 = int.Parse(destPos[1]);

            bool canMove = chess.CanPieceMove(selectedPiece, x1, y1, x2, y2);

            if (canMove)
            {
                Console.WriteLine("Данная фигура может быть перемещена на данные координаты");
            }
            else
            {
                Console.WriteLine("Данная фигура не может быть перемещена на данные координаты");
            }
        }
    }
}
