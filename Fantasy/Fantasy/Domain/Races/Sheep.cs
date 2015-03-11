using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Races
{
    /// <summary>
    /// Овца
    /// </summary>
    public class Sheep : Creature
    {

        protected override float InitialHealth
        {
            get {
                return 10;
            }
        }

        public override float Strength
        {
            get
            {
                return 2;
            }
        }

        public Sheep() : base() { }

    }
}
