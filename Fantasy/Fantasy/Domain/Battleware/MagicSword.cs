using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Battleware
{
    /// <summary>
    /// Волшебный меч
    /// </summary>
    public class MagicSword : Weapon
    {

        public override float Effect {
            get { 
                return 12;
            }
        }

        public override bool MaintainsHitTurn
        {
            get
            {
                return true;
            }
        }

    }
}
