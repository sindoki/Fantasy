using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Races;

namespace Fantasy.Interaction
{
    /// <summary>
    /// Абстракция боевых действий
    /// </summary>
    public interface IBattleActions
    {

        Creature Battle(Creature aggressor, Creature defender);

        IEnumerable<Creature> BattleGroups(IEnumerable<Creature> aggressors, IEnumerable<Creature> defenders);

    }
}
