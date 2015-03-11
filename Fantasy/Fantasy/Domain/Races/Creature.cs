using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Races
{
    /// <summary>
    /// Базовый класс: сказочное создание
    /// </summary>
    public abstract class Creature
    {

        protected abstract float InitialHealth
        {
            get;
        }

        /// <summary>
        /// Здоровье
        /// Уменьшается во время боя
        /// </summary>
        public float Health { get; set; }

        /// <summary>
        /// Сила
        /// Неизменна, характеризует здоровье, отнимаемое у противника одним ударом
        /// </summary>
        public abstract float Strength { get; }

        /// <summary>
        /// Сила существа с учетом особых обстоятельств, в том числе оружия
        /// </summary>
        public virtual float ResultStrength
        {
            get
            {
                return Strength;
            }
        }

        public bool Alive {
            get {
                return (Health > 0);
            }
        }

        /// <summary>
        /// Возможность сохранять право первого удара при встрече с вновь прибывшим противником
        /// </summary>
        public virtual bool MaintainsHitTurn
        {
            get
            {
                return false;
            }
        }

        public Creature() {
            Health = InitialHealth;
        }

    }

}
