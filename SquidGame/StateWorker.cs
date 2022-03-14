using SquidGame.StateTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SquidGame
{
    public class StateWorker
    {

        public void Start()
        {
            
            IStateMachine<char> sm = new SnakeStateMachineTable();
            
            Snake s = new Snake(10, 10);
            SnakePlayground playground = new SnakePlayground();
            char key;
            playground.Update(s);
            playground.DrawGame(s);
            //playground.DrawGame(s);
            while (s.isAlive)
            {
                Console.CursorVisible = false;
                Task.Run(() =>
                {
                    key = Console.ReadKey(true).KeyChar;
                    s.direction = sm.ChangeState(key);
                });
                playground.MoveSnakeHead(s);
                ClearConsole();
                if (playground.DetectWallCollision(s)) break; 
                playground.Update(s);
                playground.DrawGame(s);
                Thread.Sleep(500);

            }
            Console.Clear();
            Console.WriteLine("Game over loser");
        }
        protected string clearBuffer = null; // Clear this if window size changes
        protected void ClearConsole()
        {
            if (clearBuffer == null)
            {
                var line = "".PadLeft(Console.WindowWidth, ' ');
                var lines = new StringBuilder();

                for (var i = 0; i < Console.WindowHeight; i++)
                {
                    lines.AppendLine(line);
                }

                clearBuffer = lines.ToString();
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(clearBuffer);
            Console.SetCursorPosition(0, 0);
        }
    }
}
