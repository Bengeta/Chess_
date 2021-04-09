using System;
using System.Text;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var f = new Field();
            f.StartBoard();
            var g = new Game(f);
            g.StartGame();

        }
    }
    public enum State
    {
        WhiteKing,
        WhiteBishop,
        WhiteKnight,
        WhiteQueen,
        WhiteRook,
        WhitePawn,
        Empty,
        BlackKing,
        BlackBishop,
        BlackKnight,
        BlackQueen,
        BlackRook,
        BlackPawn
    }
    class Field
    {
        public Cell[,] _field;
        public void DrawBoard()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.Write(" "+(char)(i + 96));

            }
            Console.WriteLine();
            for (int i = 1; i < 9; i++)
            {
                Console.Write("" + i);
                for (int j = 0; j < 8; j++)
                    switch (_field[j, i - 1].State)
                    {
                        case State.Empty:
                            Console.Write('.' + " ");
                            break;
                        case State.WhiteKing:
                            Console.Write('♚' + " ");
                            break;
                        case State.WhiteBishop:
                            Console.Write('♝' + " ");
                            break;
                        case State.WhiteKnight:
                            Console.Write('♞' + " ");
                            break;
                        case State.WhiteQueen:
                            Console.Write('♛' + " ");
                            break;
                        case State.WhiteRook:
                            Console.Write('♜' + " ");
                            break;
                        case State.WhitePawn:
                            Console.Write('♟' + "");
                            break;
                        case State.BlackKing:
                            Console.Write('♔' + " ");
                            break;
                        case State.BlackBishop:
                            Console.Write('♗' + " ");
                            break;
                        case State.BlackKnight:
                            Console.Write('♘' + " ");
                            break;
                        case State.BlackQueen:
                            Console.Write('♕' + " ");
                            break;
                        case State.BlackRook:
                            Console.Write('♖' + " ");
                            break;
                        case State.BlackPawn:
                            Console.Write('♙' + " ");
                            break;
                    }
                Console.WriteLine();
            }

        }
        public void StartBoard()
        {
            _field = new Cell[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    _field[i, j] = new Cell();
                    _field[i, j].State = State.Empty;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                _field[i, 1] = new Cell();
                _field[i, 1].State = State.WhitePawn;
                _field[i, 6] = new Cell();
                _field[i, 6].State = State.BlackPawn;
            }
            {
                _field[0, 0] = new Cell();
                _field[0, 0].State = State.WhiteRook;
                _field[7, 0] = new Cell();
                _field[7, 0].State = State.WhiteRook;
                _field[0, 7] = new Cell();
                _field[0, 7].State = State.BlackRook;
                _field[7, 7] = new Cell();
                _field[7, 7].State = State.BlackRook;
                _field[1, 0] = new Cell();
                _field[1, 0].State = State.WhiteKnight;
                _field[6, 0] = new Cell();
                _field[6, 0].State = State.WhiteKnight;
                _field[1, 7] = new Cell();
                _field[1, 7].State = State.BlackKnight;
                _field[6, 7] = new Cell();
                _field[6, 7].State = State.BlackKnight;
                _field[2, 0] = new Cell();
                _field[2, 0].State = State.WhiteBishop;
                _field[2, 0] = new Cell();
                _field[2, 0].State = State.WhiteBishop;
                _field[5, 0] = new Cell();
                _field[5, 0].State = State.WhiteBishop;
                _field[2, 7] = new Cell();
                _field[2, 7].State = State.BlackBishop;
                _field[5, 7] = new Cell();
                _field[5, 7].State = State.BlackBishop;
                _field[3, 0] = new Cell();
                _field[3, 0].State = State.WhiteKing;
                _field[3, 7] = new Cell();
                _field[3, 7].State = State.BlackKing;
                _field[4, 0] = new Cell();
                _field[4, 0].State = State.WhiteQueen;
                _field[4, 7] = new Cell();
                _field[4, 7].State = State.BlackQueen;

            }
            DrawBoard();
        }

    }
    class Cell
    {
        private State _state;
        private bool _active;
        public State State;

        public bool Active;

    }
    class Game
    { //белые - 0 черные - 1
        private string stroke;
        private Field field;
        private int turn;
        private int xstart, ystart, xfinish, yfinish;
        public Game(Field field)
        {
            this.field = field;
        }
        public void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Дайте ход\nПример хода: e2-e4\n");
                stroke = Console.ReadLine();
                if (CheckWay()) { 
                    field._field[xfinish, yfinish].State = field._field[xstart, ystart].State;
                    field._field[xstart, ystart].State = State.Empty;
                    turn = (turn + 1) % 2;
                    field.DrawBoard();
                }

            }
        }
        public bool CheckWay()
        {
            if (stroke.Length == 5)
            {//формат строки e2-e4
                 ystart = char.IsDigit(stroke[1]) ? (int)char.GetNumericValue(stroke[1])-1 : -1;
                 xstart = char.IsLetter(stroke[0]) ? stroke[0] - 96-1 : -1;
                 yfinish = char.IsDigit(stroke[4]) ? (int)char.GetNumericValue(stroke[4])-1 : -1;
                 xfinish = char.IsLetter(stroke[3]) ? stroke[3] - 96-1 : -1;
                if ((xstart == -1 || xfinish == -1 || ystart == -1 || xfinish == -1)&&
                    (xstart >8 || xfinish >8 || ystart >8 || xfinish >8)&&
                    (xstart <0 || xfinish < 0 || ystart < 0 || xfinish < 0))
                {
                    return false;
                }
                if ((field._field[xstart, ystart].State > State.WhitePawn && turn == 0) ||//чтобы не сходить за черную фигуру если мы за белых
                    (field._field[xstart, ystart].State < State.BlackKing && turn == 1) ||// тоже самое за черных 
                    /*field._field[xstart, ystart].State < State.WhiteKing ||
                    field._field[xstart, ystart].State > State.BlackPawn ||*/
                    (field._field[xfinish, yfinish].State > State.Empty && turn == 1) ||//чтобы не съесть белую фигуру если мы за белых
                    (field._field[xfinish, yfinish].State < State.Empty && turn == 0)   // тоже самое за черных
                    )
                {
                    return false;
                }
                switch (field._field[xstart, ystart].State)
                {
                    case State.WhiteKing:
                        return KingCheck(xstart, ystart, xfinish, yfinish);
                    case State.WhiteBishop:
                        return BishopCheck(xstart, ystart, xfinish, yfinish);
                    case State.WhiteKnight:
                        return KnightCheck(xstart, ystart, xfinish, yfinish);
                    case State.WhiteQueen:
                        return QueenCheck(xstart, ystart, xfinish, yfinish);
                    case State.WhiteRook:
                        return RookCheck(xstart, ystart, xfinish, yfinish);
                    case State.WhitePawn:
                        return PawnCheck(xstart, ystart, xfinish, yfinish, 1);
                    case State.BlackKing:
                        return KingCheck(xstart, ystart, xfinish, yfinish);
                    case State.BlackBishop:
                        return BishopCheck(xstart, ystart, xfinish, yfinish);
                    case State.BlackKnight:
                        return KnightCheck(xstart, ystart, xfinish, yfinish);
                    case State.BlackQueen:
                        return QueenCheck(xstart, ystart, xfinish, yfinish);
                    case State.BlackRook:
                        return RookCheck(xstart, ystart, xfinish, yfinish);
                    case State.BlackPawn:
                        return PawnCheck(xstart, ystart, xfinish, yfinish,-1);
                }



            }
            return false;
        }
        private bool KingCheck(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x1 - x2) < 2 && Math.Abs(y1 - y2) < 2)
            {
                return true;
            }
            return false;
        }
        private bool KnightCheck(int x1, int y1, int x2, int y2)
        {
            if (((Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1)) ||
                 ((Math.Abs(x1 - x2) == 1 && Math.Abs(y1 - y2) == 2)))
            {
                return true;
            }
            return false;
        }
        private bool RookCheck(int x1, int y1, int x2, int y2)
        {
            if ((Math.Abs(x1 - x2) == 0) || (Math.Abs(y1 - y2) == 0))
            {
                if (Math.Abs(x1 - x2) == 0)
                {
                    int t = (y1 - y2) > 0 ? -1 : 1;
                    for (int i = y1 + t; i != y2; i += t)
                    {
                        if (field._field[x1, i].State != State.Empty)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                if (Math.Abs(y1 - y2) == 0)
                {
                    int t = (x1 - x2) > 0 ? -1 : 1;
                    for (int i = x1 + t; i != x2; i += t)
                    {
                        if ((field._field[i, y1].State != State.Empty))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        private bool BishopCheck(int x1, int y1, int x2, int y2)
        {
            if ((Math.Abs(x1 - x2)) == (Math.Abs(y1 - y2)))
            {
                int dx = x1 - x2 > 0 ? -1 : 1;
                int dy = (y1 - y2) > 0 ? -1 : 1;
                int j = y1+dy;
                for (int i = x1+dx; i != x2; i += dx)
                {
                    if (field._field[i, j].State != State.Empty)
                    {
                        return false;
                    }
                    j += dy;
                }
                return true;
            }
            return false;

        }
        private bool QueenCheck(int x1, int y1, int x2, int y2)
        {
            if ((Math.Abs(x1 - x2)) == (Math.Abs(y1 - y2)))
            {
                return BishopCheck(x1, y1, x2, y2);
            }
            else if ((Math.Abs(x1 - x2) == 0) || (Math.Abs(y1 - y2) == 0))
            {
                return RookCheck(x1, y1, x2, y2);
            }
            else
            {
                return false;
            }


        }
        private bool PawnCheck(int x1, int y1, int x2, int y2,int color_dep) {
                if((x1 == x2 && y2 - y1 == 1*color_dep && field._field[x1, y2].State == State.Empty)||
                    (color_dep>0 && x1 == x2 && y2==3 && y1==1 && field._field[x1, y2].State == State.Empty) ||
                     (color_dep < 0 && x1 == x2 && y2 == 4 && y1 == 6 && field._field[x1, y2].State == State.Empty))
                {
                    return true;
                }
                else if ((Math.Abs(x1 - x2) < 2) && (y2 - y1 == 1 *color_dep) && (field._field[x2, y2].State != State.Empty)) {
                    return true;
                }
                return false;
            
        }

    }
}
