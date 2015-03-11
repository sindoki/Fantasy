using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Battleware
{
    /// <summary>
    /// Обычный меч
    /// </summary>
    public class Sword : Weapon
    {
        public override float Effect {
            get {
                return 4;
            }
        }
    }
}
