using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Races;

namespace Fantasy.Interaction
{
    public class BattleActionsHonest : IBattleActions
    {

        public Creature Battle(Creature aggressor, Creature defender)
        {
            while (aggressor.Alive && defender.Alive) {
                defender.Health -= aggressor.ResultStrength;
                if (defender.Alive)
                    aggressor.Health -= defender.ResultStrength;
            }

            return aggressor.Alive ? aggressor : defender;
        }

        public IEnumerable<Creature> BattleGroups(IEnumerable<Creature> aggressors, IEnumerable<Creature> defenders)
        {
            Creature[] aggressorsCurr;
            Creature[] defendersCurr;
            IEnumerable<Creature> prevBattleSurvivers = new List<Creature>();
            int battlesCount;

            while (aggressors.Count(cr => cr.Alive) > 0 && defenders.Count(cr => cr.Alive) > 0) {
                battlesCount = Math.Min(aggressors.Count(cr => cr.Alive), defenders.Count(cr => cr.Alive));
                aggressorsCurr = aggressors.Where(cr => cr.Alive).Take(battlesCount).ToArray();
                defendersCurr = defenders.Where(cr => cr.Alive).Take(battlesCount).ToArray();
                for (int i = 0; i < battlesCount; i++) {
                    var aggressor = aggressorsCurr[i];
                    var defender = defendersCurr[i];
                    // Выживший в предыдущей схватке боец уступает вновь вступившему бойцу первый удар,
                    // если этого не исключают их особые возможности
                    if (prevBattleSurvivers.Contains(aggressor) && !prevBattleSurvivers.Contains(defender) 
                            && !(aggressor.MaintainsHitTurn && !defender.MaintainsHitTurn))
                        Battle(defender, aggressor);
                    else if (prevBattleSurvivers.Contains(defender) 
                            && defender.MaintainsHitTurn && !aggressor.MaintainsHitTurn)
                        Battle(defender, aggressor);
                    else
                        Battle(aggressor, defender);
                }
                prevBattleSurvivers = aggressorsCurr.Concat(defendersCurr).Where(cr => cr.Alive);
            }

            return aggressors.Count(cr => cr.Alive) > 0 ? aggressors : defenders;
        }
    }
}
