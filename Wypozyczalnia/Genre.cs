using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public abstract class Genre
    {
        private uint priceADay;
        private uint points;
        private string name;

        protected string Name
        {
            set { name = value; }
            get { return name; }
        }

        public uint Points
        {
            set { points = value; }
            get { return points; }
        }


        public uint PRICE_A_DAY
        {
            set { priceADay = value; }
            get { return priceADay; }
        }

        public void CountCost(uint days)
        {
            priceADay = days * PRICE_A_DAY;
        }

        public virtual void CountPoints(uint days)
        {
            if (days <= 1)
                Points = 5;
            else
                Points = days + 4;
        }
    }
}
