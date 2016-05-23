using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines.Manager.GameManager
{
    class GameContext
    {
        public int CurrentPlayer { get; set; }
        public IPlayer[] Players { get; set; }
        public int[] Score { get; set; }
        public int[] ExceptionCount { get; set; }
        public int[] ChickenCount { get; set; }
        public bool[] WinFlag { get; set; }
        public MineType[] OriginField { get; set; }
        public MineType[] PlayField { get; set; }
    }
}
