using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Linq;

namespace ClassesLibrary
{
    public class PiecePawn : Piece
    {
        private bool _PawnDiagonalNW;
        private bool _PawnDiagonalNE;
        private bool _PawnDiagonalSW;
        private bool _PawnDiagonalSE;
        public PiecePawn()
        {

        }

        public PiecePawn(string PieceName, int PieceOrder) : base(PieceName, PieceOrder)
        {

        }
        public override int[] MovementShow()
        {
            List<int> MoveList = new List<int>();
            int[] ShownMoves = new int[] { };
            if (HasMoved == false)
            {
                if (Selected && PieceColour == Color.White)
                {
                    MoveList.Add(SquareAssignment - 8);
                    MoveList.Add(SquareAssignment - 16);
                    if (PawnDiagonalNW)
                    {
                        MoveList.Add(SquareAssignment - 9);
                    }
                    if (PawnDiagonalNE)
                    {
                        MoveList.Add(SquareAssignment - 7);
                    }
                }
                else if (Selected && PieceColour == Color.Black)
                {
                    MoveList.Add(SquareAssignment + 8);
                    MoveList.Add(SquareAssignment + 16);
                    if (PawnDiagonalSE)
                    {
                        MoveList.Add(SquareAssignment + 9);
                    }
                    if (PawnDiagonalSW)
                    {
                        MoveList.Add(SquareAssignment + 7);
                    }
                }
            }
            else if (HasMoved == true)
            {
                if (Selected && PieceColour == Color.White)
                {
                    MoveList.Add(SquareAssignment - 8);
                    if (PawnDiagonalNW)
                    {
                        MoveList.Add(SquareAssignment - 9);
                    }
                    if (PawnDiagonalNE)
                    {
                        MoveList.Add(SquareAssignment - 7);
                    }
                }
                else if (Selected && PieceColour == Color.Black)
                {
                    MoveList.Add(SquareAssignment + 8);
                    if (PawnDiagonalSE)
                    {
                        MoveList.Add(SquareAssignment + 9);
                    }
                    if (PawnDiagonalSW)
                    {
                        MoveList.Add(SquareAssignment + 7);
                    }
                }
            }
            ShownMoves = MoveList.ToArray();
            return ShownMoves;
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
        
        public bool PawnDiagonalNW
        {
            get
            {
                return _PawnDiagonalNW;
            }
            set
            {
                _PawnDiagonalNW = value;
            }
        }
        public bool PawnDiagonalNE
        {
            get
            {
                return _PawnDiagonalNE;
            }
            set
            {
                _PawnDiagonalNE = value;
            }
        }
        public bool PawnDiagonalSW
        {
            get
            {
                return _PawnDiagonalSW;
            }
            set
            {
                _PawnDiagonalSW = value;
            }
        }
        public bool PawnDiagonalSE
        {
            get
            {
                return _PawnDiagonalSE;
            }
            set
            {
                _PawnDiagonalSE = value;
            }
        }
    }
}
