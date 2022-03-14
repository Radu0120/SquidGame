using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SquidGame.StateTable.SnakeStateMachineTable;

namespace SquidGame
{
    public class Snake
    {
        public int Lenght { get; set; }
        public bool isAlive { get; set; }
        public int HeadPositionX { get; set; }
        public int HeadPositionY { get; set; }
        public  Direction direction { get; set; }
        public Snake(int positionX, int positionY)
        {
            HeadPositionX = positionX;
            HeadPositionY = positionY;
            isAlive = true;
            direction = Direction.Right;
            Lenght = 1;
        }
        public void Grow()
        {
            Lenght++;
        }
    }
}
