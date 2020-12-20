using ClassesLibrary;
using System;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace ClassesLibrary
{
    public class MoveChecker
    {
        public MoveChecker()
        {

        }
        public bool CheckPiece(int i, int j, Piece P, Color C2, Piece p2)
        {
            Color C1 = P.PieceColour;
            if (i == j && C1 != C2)
            {
                return true;
            }
            return false;
        }
        public bool CheckAttackPawn(string PieceName, Piece P1, Piece P2, int XSpace, int YSpace)
        {
            if (P1.PieceName.Contains(PieceName))
            {
                int RealRow = (P2.RowSpace + 40) / 80;
                int RealColumn = (P2.ColumnSpace + 40) / 80;
                int FirstRow = (P1.RowSpace + 40) / 80;
                int FirstColumn = (P1.ColumnSpace + 40) / 80;
                //Up
                if (P2.ColumnSpace < P1.ColumnSpace && P2.RowSpace == P1.RowSpace)
                {
                    if (YSpace < RealColumn && XSpace == RealRow)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Equal Signs were changed
        public bool CheckAttackMove(string PieceName, Piece P1, Piece P2, int XSpace, int YSpace)
        {
            if (P1.PieceName.Contains(PieceName))
            {
                int RealRow = (P2.RowSpace + 40) / 80;
                int RealColumn = (P2.ColumnSpace + 40) / 80;
                int FirstRow = (P1.RowSpace + 40) / 80;
                int FirstColumn = (P1.ColumnSpace + 40) / 80;
                //Up
                if (P2.ColumnSpace < P1.ColumnSpace && P2.RowSpace == P1.RowSpace)
                {
                    if (YSpace < RealColumn && XSpace == RealRow)
                    {
                        return true;
                    }
                }
                //Down
                else if (P2.ColumnSpace > P1.ColumnSpace && P2.RowSpace == P1.RowSpace)
                {
                    if (YSpace > RealColumn && XSpace == RealRow)
                    {
                        return true;
                    }
                }
                //Left
                if (P2.RowSpace < P1.RowSpace && P2.ColumnSpace == P1.ColumnSpace)
                {
                    if (XSpace < RealRow && YSpace == RealColumn)
                    {
                        return true;
                    }
                }
                //Right
                else if (P2.RowSpace > P1.RowSpace && P2.ColumnSpace == P1.ColumnSpace)
                {
                    if (XSpace > RealRow && YSpace == RealColumn)
                    {
                        return true;
                    }
                }
                //NE 
                if (P2.RowSpace > P1.RowSpace && P2.ColumnSpace < P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace > RealRow && YSpace < RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //NW
                if (P2.RowSpace < P1.RowSpace && P2.ColumnSpace < P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace < RealRow && YSpace < RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //SE
                if (P2.RowSpace > P1.RowSpace && P2.ColumnSpace > P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace > RealRow && YSpace > RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //SW
                if (P2.RowSpace < P1.RowSpace && P2.ColumnSpace > P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace < RealRow && YSpace > RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool CheckMove(string PieceName, Piece P1, Piece P2, int XSpace, int YSpace)
        {
            //Xspace is Position of x move
            //Yspace is Position of y move
            if (P1.PieceName.Contains(PieceName))
            {
                int RealRow = (P2.RowSpace + 40) / 80;
                int RealColumn = (P2.ColumnSpace + 40) / 80;
                int FirstRow = (P1.RowSpace + 40) / 80;
                int FirstColumn = (P1.ColumnSpace + 40) / 80;
                //Up
                if (P2.ColumnSpace < P1.ColumnSpace && P2.RowSpace == P1.RowSpace)
                {
                    if (YSpace <= RealColumn && XSpace == RealRow)
                    {
                        return true;
                    }
                }
                //Down
                else if (P2.ColumnSpace > P1.ColumnSpace && P2.RowSpace == P1.RowSpace)
                {
                    if (YSpace >= RealColumn && XSpace == RealRow)
                    {
                        return true;
                    }
                }
                //Left
                if (P2.RowSpace < P1.RowSpace && P2.ColumnSpace == P1.ColumnSpace)
                {
                    if (XSpace <= RealRow && YSpace == RealColumn)
                    {
                        return true;
                    }
                }
                //Right
                else if (P2.RowSpace > P1.RowSpace && P2.ColumnSpace == P1.ColumnSpace)
                {
                    if (XSpace >= RealRow && YSpace == RealColumn)
                    {
                        return true;
                    }
                }
                //NE 
                if (P2.RowSpace > P1.RowSpace && P2.ColumnSpace < P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X*X == Y*Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace > RealRow && YSpace < RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //NW
                if (P2.RowSpace < P1.RowSpace && P2.ColumnSpace < P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace < RealRow && YSpace < RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //SE
                if (P2.RowSpace > P1.RowSpace && P2.ColumnSpace > P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace > RealRow && YSpace > RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                //SW
                if (P2.RowSpace < P1.RowSpace && P2.ColumnSpace > P1.ColumnSpace)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            //Checks if P2 is on Diagonal
                            int X = i - FirstRow;
                            int Y = j - FirstColumn;
                            if (i == RealRow && j == RealColumn && X * X == Y * Y)
                            {
                                //Check if Move is Beyond that
                                if (XSpace < RealRow && YSpace > RealColumn)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

            }
            return false;
        }

    }
}
