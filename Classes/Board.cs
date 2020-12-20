using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Data;

namespace ClassesLibrary
{

    public class Board
    {
        public Square[] Squares = new Square[64];
        private readonly List<PieceSet> _SideSets;
        private readonly PieceSet BlackChessSet = new PieceSet("BlackSet",Color.Black);
        private readonly PieceSet WhiteChessSet = new PieceSet("WhiteSet",Color.White);
        private readonly GameState GS = new GameState();
        private enum Colour
        {
            Black,
            White
        }
        private static Colour ColourAllocation = Colour.White;
        public Board()
        {
            _SideSets = new List<PieceSet>();
            LocationSet(WhiteChessSet);
            AddPieceSet(WhiteChessSet);
            LocationSet(BlackChessSet);
            AddPieceSet(BlackChessSet);

            Squares = SquareAllocaiton();
        }
        public int GameTurn()
        {
            int i = GS.Turn;
            return i;
        }
        public void LocationSet(PieceSet PS)
        {
            int Holder = 0;
            if (PS.ColourTag == Color.White)
            {
                Holder = 540;
            }
            else if (PS.ColourTag == Color.Black)
            {
                Holder = 0;
            }

            //Pawn
            for (int X = 1; X < 9; X++)
            {
                PS.FetchPiece("Pawn " + X.ToString()).RowSpace = X * 80 - 40;
                if (PS.ColourTag == Color.Black)
                {
                    PS.FetchPiece("Pawn " + X.ToString()).ColumnSpace = 120;
                    PS.FetchPiece("Pawn " + X.ToString()).SquareAssignment = 8 + X;
                }
                else if (PS.ColourTag == Color.White)
                {
                    PS.FetchPiece("Pawn " + X.ToString()).ColumnSpace = 520;
                    PS.FetchPiece("Pawn " + X.ToString()).SquareAssignment = 48 + X;
                }
            }
            //Rook, Knights, Bishops, King then Queen
            string[] PieceNameArray = new string[] { "Rook ", "Knight ", "Bishop ", "King", "Queen" };
            for (int A = 0; A < 5; A++)
            {
                //Rooks, Knights and Bishops
                if (A < 3)
                {
                    for (int X = 1; X < 3; X++)
                    {
                        PS.FetchPiece(PieceNameArray[A] + X.ToString()).RowSpace = PS.FetchPiece(PieceNameArray[A] + X.ToString()).PieceOrder * 80 - 40;

                        if (PS.ColourTag == Color.Black)
                        {
                            PS.FetchPiece(PieceNameArray[A] + X.ToString()).ColumnSpace = Holder + 40;
                            if (X == 1)
                            {
                                PS.FetchPiece(PieceNameArray[A] + X.ToString()).SquareAssignment = A + 1;

                            }
                            else
                            {
                                PS.FetchPiece(PieceNameArray[A] + X.ToString()).SquareAssignment = 8 - A;
                            }
                        }
                        else if (PS.ColourTag == Color.White)
                        {
                            PS.FetchPiece(PieceNameArray[A] + X.ToString()).ColumnSpace = Holder + 60;
                            if (X == 1)
                            {
                                PS.FetchPiece(PieceNameArray[A] + X.ToString()).SquareAssignment = A + 57;
                            }
                            else
                            {
                                PS.FetchPiece(PieceNameArray[A] + X.ToString()).SquareAssignment = 64 - A;
                            }
                        }
                    }
                }
                //King and Queen
                else
                {
                    PS.FetchPiece(PieceNameArray[A]).RowSpace = PS.FetchPiece(PieceNameArray[A]).PieceOrder * 80 - 40;
                    if (PS.ColourTag == Color.Black)
                    {
                        PS.FetchPiece(PieceNameArray[A]).ColumnSpace = Holder + 40;
                        PS.FetchPiece(PieceNameArray[A]).SquareAssignment = A + 1;
                    }
                    else if (PS.ColourTag == Color.White)
                    {
                        PS.FetchPiece(PieceNameArray[A]).ColumnSpace = Holder + 60;
                        PS.FetchPiece(PieceNameArray[A]).SquareAssignment = A + 57;
                    }
                }

            }

        }
        public List<PieceSet> SetList()
        {
            List<PieceSet> SetLists = new List<PieceSet>();
            foreach (PieceSet P in _SideSets)
            {
                SetLists.Add(P);
            }
            return SetLists;
        }
        public PieceSet FetchPieceSet(string Identifier)
        {
            foreach (PieceSet P in _SideSets)
            {
                if (P.SetName == Identifier)
                {
                    return P;
                }
            }
            return null;
        }
        public void AddPieceSet(PieceSet P)
        {
            _SideSets.Add(P);
        }
        public Square[] SquareAllocaiton()
        {
            Square[] S = new Square[64];
            for (int i = 0; i < S.Length; i++)
            {
                S[i] = new Square();
            }
            int SquareCount = 0;
            for (int Y = 1; Y < 9; Y++)
            {
                for (int X = 1; X < 9; X++)
                {
                    S[SquareCount].RowSpace = X;
                    S[SquareCount].ColumnSpace = Y;
                    S[SquareCount].SquareAssignment = SquareCount;
                    if (ColourAllocation == Colour.Black)
                    {
                        S[SquareCount].Colour = Color.Black;
                        ColourAllocation = Colour.White;
                    }
                    else if (ColourAllocation == Colour.White)
                    {
                        S[SquareCount].Colour = Color.White;
                        ColourAllocation = Colour.Black;
                    }
                    SquareCount++;
                }
            }
            return S;
            
        }
    }
}
