using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace ClassesLibrary
{
    public class PieceSet
    {
        private readonly List<Piece> _PieceList;
        private Color _SetColour;
        private string _SetName;

        //Pawn 1
        private readonly PiecePawn TestPawn1 = new PiecePawn("Pawn 1", 1);
        private readonly PiecePawn TestPawn2 = new PiecePawn("Pawn 2", 2);
        private readonly PiecePawn TestPawn3 = new PiecePawn("Pawn 3", 3);
        private readonly PiecePawn TestPawn4 = new PiecePawn("Pawn 4", 4);
        private readonly PiecePawn TestPawn5 = new PiecePawn("Pawn 5", 5);
        private readonly PiecePawn TestPawn6 = new PiecePawn("Pawn 6", 6);
        private readonly PiecePawn TestPawn7 = new PiecePawn("Pawn 7", 7);
        private readonly PiecePawn TestPawn8 = new PiecePawn("Pawn 8", 8);

        //Rooks
        private readonly PieceRook TestRook1 = new PieceRook("Rook 1", 1);
        private readonly PieceRook TestRook2 = new PieceRook("Rook 2", 8);

        //Knights
        private readonly PieceKnight TestKnight1 = new PieceKnight("Knight 1", 2);
        private readonly PieceKnight TestKnight2 = new PieceKnight("Knight 2", 7);

        //Bishops
        private readonly PieceBishop TestBishop1 = new PieceBishop("Bishop 1", 3);
        private readonly PieceBishop TestBishop2 = new PieceBishop("Bishop 2", 6);

        //King and Queen
        private readonly PieceKing TestKing = new PieceKing("King", 4);
        private readonly PieceQueen TestQueen = new PieceQueen("Queen", 5);

        public PieceSet()
        {

        }
        public PieceSet(string SetName,Color C)
        {
            _PieceList = new List<Piece>();
            _SetName = SetName;
            _SetColour = C;
            ChessAdd();
            ColourAllocation(C);
            ChessAddDictionary();
        }
        public void ChessAddDictionary()
        {
            Piece.RegisterPiece("Pawn 1", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 2", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 3", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 4", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 5", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 6", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 7", typeof(PiecePawn));
            Piece.RegisterPiece("Pawn 8", typeof(PiecePawn));

            Piece.RegisterPiece("Rook 1", typeof(PieceRook));
            Piece.RegisterPiece("Rook 1", typeof(PieceRook));

            Piece.RegisterPiece("Knight 1", typeof(PieceKnight));
            Piece.RegisterPiece("Knight 2", typeof(PieceKnight));

            Piece.RegisterPiece("Bishop 1", typeof(PieceBishop));
            Piece.RegisterPiece("Bishop 2", typeof(PieceBishop));

            Piece.RegisterPiece("King", typeof(PieceKing));
            Piece.RegisterPiece("Queen", typeof(PieceKing));
        }
        public void ChessAdd()
        {
            AddPiece(TestPawn1);
            AddPiece(TestPawn2);
            AddPiece(TestPawn3);
            AddPiece(TestPawn4);
            AddPiece(TestPawn5);
            AddPiece(TestPawn6);
            AddPiece(TestPawn7);
            AddPiece(TestPawn8);
            AddPiece(TestRook1);
            AddPiece(TestRook2);
            AddPiece(TestBishop1);
            AddPiece(TestBishop2);
            AddPiece(TestKnight1);
            AddPiece(TestKnight2);
            AddPiece(TestKing);
            AddPiece(TestQueen);
        }
        public List<Piece> PieceList()
        {
            List<Piece> PieceList = new List<Piece>();
            foreach (Piece P in _PieceList)
            {
                PieceList.Add(P);
            }
            return PieceList;
        }
        public void AddPiece(Piece P)
        {
            _PieceList.Add(P);
        }
        public void RemovePiece(Piece P)
        {
            _PieceList.Remove(P);
        }
        public void ColourAllocation(Color C)
        {
            foreach (Piece P in _PieceList)
            {
                P.PieceColour = C;
            }
        }

        public Piece FetchPiece(string Identifier)
        {
            foreach (Piece P in _PieceList)
            {
                if (P.PieceName == Identifier)
                {
                    return P;
                }
            }
            return null;
        }

        public PiecePawn FetchPawn(string Identifier)
        {
            foreach (PiecePawn P in _PieceList)
            {
                if (P.PieceName == Identifier)
                {
                    return P;
                }
            }
            return null;
        }
        public Color OppositeColour()
        {
            Color Opposite = ColourTag;
            if (ColourTag == Color.Black)
            {
                Opposite = Color.White;                
            }
            else if (ColourTag == Color.White)
            {
                Opposite = Color.Black;
            }
            return Opposite;
        }

        public Color ColourTag
        {
            get
            {
                return _SetColour;
            }
            set
            {
                _SetColour = value;
            }
        }
        public string SetName
        {
            get
            {
                return _SetName;
            }
            set
            {
                _SetName = value;
            }
        }
    }
}
