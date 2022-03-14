using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SquidGame.StateTable.SnakeStateMachineTable;

namespace SquidGame
{
    public interface IStateMachine<T>
    {
        bool NextInput(T input);
        Direction ChangeState(T input);
    }
}
