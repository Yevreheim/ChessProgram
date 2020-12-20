using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLibrary
{
    public class PieceKnight : Piece
    {
        public PieceKnight()
        {

        }
        public PieceKnight(string PieceName, int PieceOrder) : base(PieceName, PieceOrder)
        {

        }
        public override Square Attacking()
        {
            throw new NotImplementedException();
        }
        public override Square Free()
        {
            throw new NotImplementedException();
        }
        public override Square GettingAttacked()
        {
            throw new NotImplementedException();
        }

        public override int[] MovementShow()
        {
            List<int> MoveList = new List<int>();
            int[] ShownMoves = new int[] { };
            //Total Array
            int[] TotalArray = new int[] { SquareAssignment - 15, SquareAssignment - 6, SquareAssignment + 10, SquareAssignment + 17, SquareAssignment + 15, SquareAssignment + 6, SquareAssignment - 10, SquareAssignment - 17 };

            foreach (int i in TotalArray)
            {
                if (HorizontalChecker(i))
                {
                    if (WallSecondCross(i))
                    {
                        if(AtWall(i))
                        {
                            MoveList.Add(i);
                        }
                    }
                }
            }

            ShownMoves = MoveList.ToArray();
            return ShownMoves;
        }
        private bool AtWall(int A)
        {
            bool Check = true;
            //Right
            int[] RightSideArray = new int[] { SquareAssignment - 15, SquareAssignment - 6, SquareAssignment + 10, SquareAssignment + 17 };
            //Left
            int[] LeftSideArray = new int[] { SquareAssignment + 15, SquareAssignment + 6, SquareAssignment - 10, SquareAssignment - 17 };
            for (int i = 1; i < 9; i++)
            {
                //Right
                foreach (int z in RightSideArray)
                {
                    if (SquareAssignment == 8 * i && A == z)
                    {
                        return false;
                    }
                }
                //Left
                foreach (int z in LeftSideArray)
                {
                    if (SquareAssignment == 8*i-7 && A == z)
                    {
                        return false;
                    }
                }
            }
            return Check;
        }
        private bool WallSecondCross(int A)
        {
            bool Check = true;
            for (int i = 1; i < 9; i++)
            {
                //2nd From Right
                if (SquareAssignment + 1 == 8*i &&  (A == 8 *i + 9 || (A == 8*i - 7)))
                {
                    return false;
                }
                //2nd from Left
                else if (SquareAssignment == 8 *i - 6 && (A == 8*i || A == 8*(i-2)))
                {
                    return false;
                }
            }
            return Check;
        }
        private bool HorizontalChecker(int A)
        {
            int Holder8 = 0;
            int Upper = 0;
            int Lower = 0;
            bool Checker = false;
            List<int> HorizontalRestriction = new List<int>();
            //Horizontal
            for (int i = 0; i < 9; i++)
            {
                if (SquareAssignment <= 8 * i)
                {
                    Holder8 = 8 * i;
                    Upper = Holder8 - SquareAssignment;
                    Lower = SquareAssignment - (8 * (i - 1)) - 1;
                    break;
                }
            }
            //Horizontal Right
            for (int i = 0; i < Upper; i++)
            {
                HorizontalRestriction.Add(SquareAssignment + i + 1);
            }
            //Left
            for (int i = 0; i < Lower; i++)
            {
                HorizontalRestriction.Add(SquareAssignment - i - 1);
            }
            foreach (int i in HorizontalRestriction)
            {
                if (A != i)
                {
                    Checker = true;
                    continue;
                }
                else if (A == i)
                {
                    Checker = false;
                    break;
                }
            }
            return Checker;
        }
    }
}
