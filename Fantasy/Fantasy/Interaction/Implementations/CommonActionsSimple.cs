using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Enums;
using Fantasy.Races;

namespace Fantasy.Interaction
{
    public class CommonActionsSimple : ICommonActions
    {

        public IActionsChecker ActionsChecker
        {
            get;
            set;
        }

        public IBattleActions BattleActions
        {
            get;
            set;
        }

        public EatAttemptResult TryToEat(AggressiveCreature aggressor, Creature victim)
        {

            if (!ActionsChecker.IsFoodChainCorrect(aggressor, victim))
                throw new FoodChainViolationException();

            if (!aggressor.Alive)
                return EatAttemptResult.Fail;
            if (!victim.Alive)
                return EatAttemptResult.Success;

            Creature victor = BattleActions.Battle(aggressor, victim);
            if (victor == aggressor)
                return EatAttemptResult.Success;
            else
                return EatAttemptResult.Fail;
        }

        public EatAttemptResult TryToEat(IEnumerable<AggressiveCreature> aggressors, IEnumerable<Creature> victims)
        {

            if (aggressors.Any(ag => victims.Any(vm => !ActionsChecker.IsFoodChainCorrect(ag, vm))))
                return EatAttemptResult.Fail;

            if (aggressors.Count(cr => cr.Alive) == 0)
                return EatAttemptResult.Fail;

            if (victims.Count(cr => cr.Alive) == 0)
                return EatAttemptResult.Success;

            IEnumerable<Creature> victors = BattleActions.BattleGroups(aggressors, victims);

            if (victors == aggressors)
                return EatAttemptResult.Success;
            else
                return EatAttemptResult.Fail;
        }

    }
}
