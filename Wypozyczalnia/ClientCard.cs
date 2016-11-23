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

        public uint AddPoints(Movie movie, uint days)
        {
            uint points = 0;
            movie.getGenre.CountPoints(days);
            points = movie.getGenre.Points;
            return points;
        }
    }
}
