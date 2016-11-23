using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Novelty : Genre
    {
        public Novelty()
        {
            Name = "Novelty";
            PRICE_A_DAY = 5;
        }
        public override void CountPoints(uint days)
        {
            if (days <= 1)
                Points = 10;
            else
                Points = 2 * (days + 4);
        }
    }
}
