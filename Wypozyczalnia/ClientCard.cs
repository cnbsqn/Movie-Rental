using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class ClientCard
    {
        public ClientCard() { }

        private string id;
        private uint points;
        private uint counted_cost;

        public uint Points
        {
            get { return points; }
            set { points = value; }
        }

        public uint Counted_cost
        {
            get { return counted_cost; }
            set { counted_cost = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public uint addPoints(uint movie_price, uint days)
        {
            uint points = 0;
            if (movie_price == (int)Movie.TYPE.normal)
                points += days;
            else if (movie_price == (int)Movie.TYPE.novelty)
                points += 2 * days;
            else
                points = 0;

            return points;
        }
    }
}
