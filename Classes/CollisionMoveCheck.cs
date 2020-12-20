using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Transactions;

namespace ClassesLibrary
{
    public class CollisionMoveCheck
    {
        private readonly MoveChecker MoveCheck = new MoveChecker();
        private bool PawnCheck = new bool();
        private bool PawnCheck2 = new bool();
        private bool RookCheck = new bool();
        private bool QueenCheck = new bool();
        private bool BishopCheck = new bool();
        private bool PieceCheck = new bool();
        private bool CastleCheck = new bool();
        public CollisionMoveCheck()
        {

        }
        public bool CollisionCheck(List<Piece> P,Piece P1, int cGBX, int cGBY, int DesignationOverride, Color C1)
        {
            foreach (Piece P2 in P)
            {
                PieceCheck = MoveCheck.CheckPiece(DesignationOverride, P2.SquareAssignment, P2, C1, P1);
                PawnCheck = MoveCheck.CheckMove("Pawn", P1, P2, cGBX, cGBY);
                RookCheck = MoveCheck.CheckMove("Rook", P1, P2, cGBX, cGBY);
                QueenCheck = MoveCheck.CheckMove("Queen", P1, P2, cGBX, cGBY);

                BishopCheck = MoveCheck.CheckMove("Bishop", P1, P2, cGBX, cGBY);
                if (PieceCheck || PawnCheck || RookCheck || QueenCheck || BishopCheck)
                {
                    if (CastleCheck)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        public bool CollisionAttackCheck(List<Piece> P, Piece P1, int cGBX, int cGBY, int DesignationOverride, Color C1)
        {
            foreach (Piece P2 in P)
            {
                PawnCheck = MoveCheck.CheckAttackPawn("Pawn", P1, P2, cGBX, cGBY);
                PawnCheck2 = MoveCheck.CheckMove("Pawn", P1, P2, cGBX, cGBY); // Required for Veritcal Movement
                RookCheck = MoveCheck.CheckAttackMove("Rook", P1, P2, cGBX, cGBY);
                BishopCheck = MoveCheck.CheckAttackMove("Bishop", P1, P2, cGBX, cGBY);
                QueenCheck = MoveCheck.CheckAttackMove("Queen", P1, P2, cGBX, cGBY);
                if ( RookCheck || QueenCheck || BishopCheck || PawnCheck || PawnCheck2 )
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckIfAttackingPiece(PieceSet PS1, int cGBX, int cGBY, int DesignationOverride)
        {
            //PS1 = Opposite Colour Set
            foreach (Piece P2 in PS1.PieceList())
            {
                int P2Row = (P2.RowSpace + 40) / 80;
                int P2Column = (P2.ColumnSpace + 40) / 80;
                if (cGBX == P2Row && cGBY == P2Column)
                {
                    Console.WriteLine("Found Fish in the Sea");
                    return true;
                }
            }
            return false;
        }
        public bool CheckIfCheck(Piece P, PieceSet PS)
        {
            foreach (Piece P2 in PS.PieceList())
            {
                foreach (Moves M in P2.MoveList())
                {
                    if (M.SquareAssignment == P.SquareAssignment)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckinCheckSet(PieceSet PS1, PieceSet PS2)
        {
            foreach (Piece P1 in PS1.PieceList())
            {
                foreach (Moves M in P1.MoveList())
                {
                    if (M.SquareAssignment == PS2.FetchPiece("King").SquareAssignment)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
