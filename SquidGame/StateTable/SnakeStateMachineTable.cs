using System;
using System.Collections.Generic;
using System.Text;

namespace SquidGame.StateTable
{
    public class SnakeStateMachineTable : IStateMachine<char>
    {
        //private int Direction = 0;
        public enum Direction
        {
            Up, Down, Left, Right
        }
        private Direction currentState;
        private StateMachineEntry[,] _sm;

        public SnakeStateMachineTable()
        {
            _sm = new StateMachineEntry[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _sm[i, j] = new StateMachineEntry() { NextState = 4, Accepted = false };
                }
            }
            //state up
            _sm[0, 0] = new StateMachineEntry() { NextState = 0, Accepted = true }; // state up input w (=0)
            _sm[2, 0] = new StateMachineEntry() { NextState = 2, Accepted = true }; // state up input a (=2)
            _sm[3, 0] = new StateMachineEntry() { NextState = 3, Accepted = true }; // state up input d (=3)
            //state down
            _sm[1, 1] = new StateMachineEntry() { NextState = 1, Accepted = true }; // state down input s (=1)
            _sm[2, 1] = new StateMachineEntry() { NextState = 2, Accepted = true }; // state down input a (=2)
            _sm[3, 1] = new StateMachineEntry() { NextState = 3, Accepted = true }; // state down input d (=3)
            //state left
            _sm[2, 2] = new StateMachineEntry() { NextState = 2, Accepted = true }; // state left input a (=2)
            _sm[0, 2] = new StateMachineEntry() { NextState = 0, Accepted = true }; // state left input w (=0)
            _sm[1, 2] = new StateMachineEntry() { NextState = 1, Accepted = true }; // state left input s (=1)
            //state right
            _sm[3, 3] = new StateMachineEntry() { NextState = 3, Accepted = true }; // state right input d (=3)
            _sm[0, 3] = new StateMachineEntry() { NextState = 0, Accepted = true }; // state right input w (=0)
            _sm[1, 3] = new StateMachineEntry() { NextState = 1, Accepted = true }; // state right input s (=1)
        }


        public bool NextInput(char input)
        {
            StateMachineEntry entry = _sm[ConvertInput(input), (int)currentState];
            currentState = (Direction)entry.NextState;
            return entry.Accepted;
        }
        public Direction ChangeState(char input)
        {
            StateMachineEntry entry = _sm[ConvertInput(input), (int)currentState];
            if (entry.Accepted)
            {
                currentState = (Direction)entry.NextState;
            }
            return currentState;
        }

        private int ConvertInput(char c)
        {
            switch (c)
            {
                case 'w': return 0;
                case 's': return 1;
                case 'a': return 2;
                case 'd': return 3;
                default: return 4;
            }
            //if (c == 'a' || c == 'b' || c == 'c')
            //{
            //    return (int)c - (int)'a';
            //}

            //return 4;


        }
    }

    struct StateMachineEntry
    {
        public int NextState;
        public bool Accepted;
    }
}
