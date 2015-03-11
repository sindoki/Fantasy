using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Enums;
using Fantasy.Races;

namespace Fantasy.Interaction
{
    public interface ICommonActions
    {

        IActionsChecker ActionsChecker { get; set; }

        IBattleActions BattleActions { get; set; }

        EatAttemptResult TryToEat(AggressiveCreature aggressor, Creature victim);

        EatAttemptResult TryToEat(IEnumerable<AggressiveCreature> aggressors, IEnumerable<Creature> victims);

    }
}
