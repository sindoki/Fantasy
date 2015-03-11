using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Races;

namespace Fantasy.Interaction
{
    public interface IActionsChecker
    {

        bool IsFoodChainCorrect(AggressiveCreature aggressor, Creature victim);

    }
}
