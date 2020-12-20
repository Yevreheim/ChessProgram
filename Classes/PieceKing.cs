using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLibrary
{
    public class PieceKing : Piece
    {

        public PieceKing()
        {

        }
        public PieceKing(string PieceName, int PieceOrder) : base(PieceName, PieceOrder)
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
            int Holder = 0;
            //Down
            MoveList.Add(SquareAssignment + 8);
            //Up
            MoveList.Add(SquareAssignment - 8);
            //Left, Right + Intercardinals
            for(int i = 0; i < 9; i++){
                //Right + Boundaries
                if (SquareAssignment < 8 * i && SquareAssignment > 8*(i-1))
                {
                    MoveList.Add(SquareAssignment + 1);
                    //NE
                    MoveList.Add(SquareAssignment - 7);
                    //SE
                    MoveList.Add(SquareAssignment + 9);
                }
                //Left
                if (SquareAssignment - 1 < 8 * i && SquareAssignment - 1 > 8 * (i - 1) && SquareAssignment - 1 != 0)
                {
                    MoveList.Add(SquareAssignment - 1);
                    //NW
                    MoveList.Add(SquareAssignment - 9);
                    //SW
                    MoveList.Add(SquareAssignment + 7);
                }
            }
            ShownMoves = MoveList.ToArray();
            return ShownMoves;
        }

    }
}
