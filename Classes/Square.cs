using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Square 
    {
        private int _row;
        private int _column;
        private Color _colour;
        private int _SquareAssignment;
        public Square()
        {

        }
        public Square(int rows, int columns)
        {
            _row = rows;
            _column = columns;
        }
        public Square(int rows, int columns, int Designation)
        {
            _row = rows;
            _column = columns;
            _SquareAssignment = Designation;
        }
        public Color Colour
        {
            get
            {
                return _colour;
            }
            set
            {
                _colour = value;
            }
        }
        public int RowSpace
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }

        }
        public int ColumnSpace
        {
            get
            {
                return _column;
            }
            set
            {
                _column = value;
            }
        }
        public int SquareAssignment
        {
            get
            {
                return _SquareAssignment;
            }
            set
            {
                _SquareAssignment = value;
            }
        }

    }
}
