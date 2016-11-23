using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Movie
    {
        public enum GENRE
        {
            thriller,
            comedy,
            action,
            romantic,
            for_kids,
            adventure,
            fantasy,
            scifi,
            action_film,
            drama,
            Western
        }

        public Movie(string title, string director, GENRE[] genre, uint length, uint release_year)
        {
            this.title = title;
            this.director = director;
            this.genre = genre;
            this.length = length;
            this.release_year = release_year;
            movie_id = counter.ToString();
            counter++;
        }

        private string movie_id;
        private static int counter = 0;

        private GENRE[] genre;
        private string title;
        private string director;
        private uint length;
        private uint price;
        private uint release_year;
        private uint days;
        private Genre genre_class;

        public Genre getGenre
        {
            get { return genre_class; }
        }

        public uint Days
        {
            set { days = value; }
            get { return days; }
        }

        public string Title { get { return title; } }
        public string Director { get { return director; } }
        public uint Length { get { return length; } }
        public uint Price { get { return price; } set { price = value; } }
        public uint Release_year { get { return release_year; } }

        public string Genre(GENRE[] genre)
        {
            string movie_genre = null;

            for (int i = 0; i < genre.Length; i++)
                movie_genre = genre[i] + " ";

            return movie_genre;
        }

        public void addTypeToMovie()
        {
            DateTime currentYear = DateTime.Today;
            for (int i = 0; i < genre.Length; i++)
            {
                if (release_year == currentYear.Year)
                    genre_class = new Novelty();
                else if (genre[i] == GENRE.for_kids)
                    genre_class = new ForKids();
                else if (genre[i] == GENRE.Western)
                    genre_class = new Western();
                else
                    genre_class = new Normal();
            }

            genre_class.CountCost(days);
            price = genre_class.PRICE_A_DAY;

        }

        public string getID() { return movie_id; }

        public override string ToString()
        {
            return "Title: " + title + " director: " + director +
                   " genre: " + Genre(genre) + " length: " + length;
        }

    }
}
