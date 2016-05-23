using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines.Manager.PlayerManager
{
    public class PlayerGenerator
    {
        private Type playerType;

        public PlayerGenerator(Type playerType)
        {
            this.playerType = playerType;
        }

        public IPlayer New()
        {
            return Activator.CreateInstance(playerType) as IPlayer;
        }
    }
}
