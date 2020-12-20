using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ClassesLibrary
{
    public class Player
    {
        private string _Name;
        private bool _Turn;
        private Color _PlayerColour;
        public Player()
        {

        }
        public Player(string N, Color C)
        {
            _Name = N;
            _PlayerColour = C;
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value; 
            }
        }
        public Color PlayerColour
        {
            get
            {
                return _PlayerColour;
            }
            set
            {
                _PlayerColour = value;
            }
        }
        public bool Turn
        {
            get
            {
                return _Turn;
            }
            set
            {
                _Turn = value;
            }
        }
    }
}
