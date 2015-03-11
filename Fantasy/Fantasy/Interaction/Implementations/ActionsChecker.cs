using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Races;

namespace Fantasy.Interaction
{
    public class ActionsChecker : IActionsChecker
    {
        public bool IsFoodChainCorrect(AggressiveCreature aggressor, Creature victim)
        {
            return (victim is Goblin || victim is Sheep);
        }
    }
}
