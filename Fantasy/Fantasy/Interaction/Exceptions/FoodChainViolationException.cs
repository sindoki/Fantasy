using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Interaction
{
    public class FoodChainViolationException : Exception
    {

        public FoodChainViolationException() : base("Food chain violation") { }

    }
}
