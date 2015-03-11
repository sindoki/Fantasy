using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Races
{
    public class Goblin : AggressiveCreature
    {

        protected override float InitialHealth
        {
            get {
                return 20;
            }
        }

        public override float Strength
        {
            get {
                return 8;
            }
        }

        public Goblin() : base() { }

    }
}
