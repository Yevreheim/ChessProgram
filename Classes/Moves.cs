using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLibrary
{
    public class Moves : Square
    {
        private bool _Attacking;
        public Moves()
        {

        }

        public Moves(int X, int Y, int Designation) : base (X,Y,Designation)
        {

        }
        public bool Attacking
        {
            get
            {
                return _Attacking;
            }
            set
            {
                _Attacking = value;
            }
        }
       
    }
}
