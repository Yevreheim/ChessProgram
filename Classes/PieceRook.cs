using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ClassesLibrary
{
    public class PieceRook : Piece
    {
        public PieceRook()
        {

        }
        public PieceRook(string PieceName, int PieceOrder) : base(PieceName, PieceOrder)
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
            //Vertical
            for (int i = 1; i < 8; i++)
            {
                MoveList.Add(SquareAssignment - 8 * i);
                MoveList.Add(SquareAssignment + 8 * i);
            }
            //Horizontal
            for(int i = 0; i < 9; i++)
            {
                if (SquareAssignment <= 8 * i)
                {
                    Holder8 = 8 * i;
                    Upper = Holder8 - SquareAssignment;
                    Lower = SquareAssignment - (8 * (i - 1)) - 1;
                    break;
                }
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
