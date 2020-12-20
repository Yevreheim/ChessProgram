using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class PieceBishop : Piece
    {
        public PieceBishop()
        {

        }
        public PieceBishop(string PieceName, int PieceOrder) : base(PieceName, PieceOrder)
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
            //Right
            for (int i = 1; i <= Upper; i++)
            {
                //NE
                MoveList.Add(SquareAssignment - 7*i);
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

            ShownMoves = MoveList.ToArray();
            return ShownMoves;
        }
    }
}
