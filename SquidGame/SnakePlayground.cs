using SquidGame.StateTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquidGame
{
    public class SnakePlayground
    {
        public static int[,] Playground { get; set; }
        IStateMachine<char> sm = new SnakeStateMachineTable();
        private int m = 20;
        private int n = 20;
        Random rnd;
        public SnakePlayground()
        {
            Playground = new int[m,n];
            rnd = new Random();
        }
        public bool DetectWallCollision(Snake s)
        {
            if (s.HeadPositionX > m || s.HeadPositionX < 0 || s.HeadPositionY > n || s.HeadPositionY < 0)
            {
                s.isAlive = false;
                return true;
            }
            return false;
        }
        public void MoveSnakeHead(Snake s)
        {
            if (s.direction == SnakeStateMachineTable.Direction.Up) s.HeadPositionX--;
            else if(s.direction == SnakeStateMachineTable.Direction.Down) s.HeadPositionX++;
            else if (s.direction == SnakeStateMachineTable.Direction.Right) s.HeadPositionY++;
            else if (s.direction == SnakeStateMachineTable.Direction.Left) s.HeadPositionY--;
        }
        public void Update(Snake s)
        {
            rnd.Next(0, 20);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Playground[i, j] = 0;
                }
            }
            Playground[s.HeadPositionX, s.HeadPositionY] = 1;
        }
        public void DrawGame(Snake s)
        {
            for (int i = 0; i<m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Playground[i, j] == Playground[s.HeadPositionX, s.HeadPositionY]) Console.Write("S ");
                    else Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }
    }
}
