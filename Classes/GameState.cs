using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ClassesLibrary
{
    public class GameState
    {
        private int _turn;
        private bool _CheckMate;
        private string _GameStateHolder;
        private Color _C;
        private enum GameStateCurrently
        {
            BlackIsInCheck,
            WhiteIsInCheck,
            GameRunning,
            BlackWins,
            WhiteWins
        }
        private static GameStateCurrently GameAllocation = GameStateCurrently.GameRunning;
        public GameState()
        {

        }
        public void ChangeGameState(string State)
        {
            _GameStateHolder = State;
        }
        public string GameStateHolder
        {
            get
            {
                return _GameStateHolder;
            }
            set
            {
                _GameStateHolder = value;
            }
        }
        public string GameStateCheck
        {
            get
            {
                string GameString = GameAllocation.ToString();
                if (_GameStateHolder != null)
                {
                    if (CheckMate==true)
                    {
                        return _C.ToString() +" Player Wins";
                    }
                    GameString = _GameStateHolder;
                }
                return GameString;
            }
        }
        public bool CheckMate
        {
            get
            {
                return _CheckMate;
            }
            set
            {
                _CheckMate = value;
            }
        }
        public Color C
        {
            get
            {
                return _C;
            }
            set
            {
                _C = value;
            }
        }
        public int Turn
        {
            get
            {
                return _turn;
            }
            set
            {
                _turn = value;
            }
        }
    }
}
