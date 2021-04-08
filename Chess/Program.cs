using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Field();
            f.StartBoard();
           
        }
    }
    public enum State
    {
        Empty,
        WhiteKing,
        WhiteBishop,
        WhiteKnight,
        WhiteQueen,
        WhiteRook,
        WhitePawn,
        BlackKing,
        BlackBishop,
        BlackKnight,
        BlackQueen,
        BlackRook,
        BlackPawn
    }
    class Field{
        private Cell[,] _field;
        public void DrawBoard() {
            for (int i = 1; i < 9; i++)
            {
                Console.Write(" "+i);

            }
            Console.WriteLine();
            for (int i = 1; i < 9; i++)
            {
                Console.Write((char)(i + 96) + " ");
                for (int j = 0; j < 8; j++)
                    switch (_field[j, i-1].State) {
                        case State.Empty:
                            Console.Write('.'+" ");
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
                            Console.Write('♟' + " ");
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
}
