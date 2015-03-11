using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Battleware
{
    /// <summary>
    /// Оружие
    /// Базовый класс
    /// </summary>
    public abstract class Weapon
    {

        /// <summary>
        /// Эффект оружия - множитель силы существа, владеющего им
        /// В начальной реализации виды оружия различаются лишь значением эффекта
        /// </summary>
        public abstract float Effect { get; }

        /// <summary>
        /// Возможность сохранять право первого удара при встрече с вновь прибывшим противником
        /// </summary>
        public virtual bool MaintainsHitTurn {
            get
            {
                return false;
            }
        }

    }
}
