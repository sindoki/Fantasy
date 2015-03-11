using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Races
{
    public class Ogre : AggressiveCreature
    {
        protected override float InitialHealth
        {
            get {
                return 60;
            }
        }

        public override float Strength
        {
            get {
                return 16;
            }
        }

        public Ogre() : base() { }

    }
}
