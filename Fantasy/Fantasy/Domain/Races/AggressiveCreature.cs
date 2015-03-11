using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy.Battleware;
using Fantasy.Enums;

namespace Fantasy.Races
{
    /// <summary>
    /// Агрессивное существо, способное есть других и владеющее оружием
    /// </summary>
    public abstract class AggressiveCreature : Creature
    {

        public Weapon Weapon { get; set; }

        public override float ResultStrength
        {
            get
            {
                return Strength * (Weapon == null ? 1 : Weapon.Effect);
            }
        }

        public override bool MaintainsHitTurn
        {
            get
            {
                return (Weapon != null && Weapon.MaintainsHitTurn);
            }
        }

    }

}
