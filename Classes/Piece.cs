using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public abstract class Piece : Square
    {
        public enum PieceType
        {
            Pawn,
            King,
            Queen,
            Rook,
            Bishop,
            Knight
        }
        private Color _PieceColour;
        private string _PieceName;
        private int _PieceOrder;
        private bool _Selected;
        private bool _HasMoved;
        private bool _CanSeeAttack;
        private List<Moves> _Moves;
        private List<int> _IntMoves;
        private static readonly Dictionary<string, Type> _PieceClassRegistry = new Dictionary<string, Type>();

        //private static List<Moves> _Moves;
        public Piece()
        {
            PieceColour = _PieceColour;
        }
        public Piece(string PieceID, int PiecePlaceId)
        {
            _PieceName = PieceID;
            _PieceOrder = PiecePlaceId;
            _Moves = new List<Moves>();
        }

        public abstract int[] MovementShow();
        public abstract Square Attacking();
        public abstract Square Free();
        public abstract Square GettingAttacked();
        public static void RegisterPiece(string Name, Type T)
        {
            _PieceClassRegistry[Name] = T;
        }
        public static Piece CreatePiece(string Name)
        {
            return (Piece)Activator.CreateInstance(_PieceClassRegistry[Name]);
        }
        public static string GetKey(Type T)
        {
            foreach (KeyValuePair<string, Type> PieceDictionary in _PieceClassRegistry)
            {
                if (T == PieceDictionary.Value)
                {
                    return PieceDictionary.Key;
                }
            }
            return null;
        }
        public List<Moves> MoveList()
        {
            List<Moves> MovingList = new List<Moves>();
            foreach (Moves M in _Moves)
            {
                MovingList.Add(M);
            }
            return MovingList;
        }
        public void AddMove(int x, int y, int Designation)
        {
            Moves NewMove = new Moves(x,y,Designation);
            _Moves.Add(NewMove);
        }
        public void RemoveMove(int x,int y, int Designation)
        {
            Moves NewMove = new Moves(x, y, Designation);
            _Moves.Remove(NewMove);
        }


        public string PieceName
        {
            get
            {
                return _PieceName;
            }
            set
            {
                _PieceName = value;
            }
        }
        public List<Moves> ListofMoves
        {
            get
            {
                return _Moves;
            }
            set
            {
                _Moves = value;
            }
        }
        public List<int> IntMoves
        {
            get
            {
                return _IntMoves;
            }
            set
            {
                _IntMoves = value;
            }
        }
        public Color PieceColour
        {
            get
            {
                return _PieceColour;
            }
            set
            {
                _PieceColour = value;
            }
        }
        public int PieceOrder
        {
            get
            {
                return _PieceOrder;
            }
            set
            {
                _PieceOrder = value;
            }
        }
        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
            }
        }
        public bool HasMoved
        {
            get
            {
                return _HasMoved;
            }
            set
            {
                _HasMoved = value;
            }
        }
        public bool CanSeeAttack
        {
            get
            {
                return _CanSeeAttack;
            }
            set
            {
                _CanSeeAttack = value;
            }
        }




    }
}
