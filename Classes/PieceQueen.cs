using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLibrary
{
    public class PieceQueen : Piece
    {
        public PieceQueen()
        {

        }
        public PieceQueen(string PieceName, int PieceOrder) : base(PieceName, PieceOrder)
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
            int Holder8 = 0;
            int Upper = 0;
            int Lower = 0;
            List<int> MoveList = new List<int>();
            int[] ShownMoves = new int[] { };
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
            //Vertical
            for (int i = 1; i < 8; i++)
            {
                MoveList.Add(SquareAssignment - 8 * i);
                MoveList.Add(SquareAssignment + 8 * i);
            }
            //Right
            for (int i = 1; i <= Upper; i++)
            {
                //NE
                MoveList.Add(SquareAssignment - 7 * i);
                //SE
                MoveList.Add(SquareAssignment + 9 * i);

            }
            //Left
            for (int i = 1; i <= Lower; i++)
            {
                //SW
                MoveList.Add(SquareAssignment + 7 * i);
                //NW
                MoveList.Add(SquareAssignment - 9 * i);

            }
            //Right
            for (int i = 0; i < Upper; i++)
            {
                MoveList.Add(SquareAssignment + i + 1);
            }
            //Left
            for (int i = 0; i < Lower; i++)
            {
                MoveList.Add(SquareAssignment - i - 1);
            }

            ShownMoves = MoveList.ToArray();
            return ShownMoves;
        }
    }
}
