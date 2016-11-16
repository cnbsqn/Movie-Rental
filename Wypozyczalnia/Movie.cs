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
            drama
        }

        public enum TYPE
        {
            normal = 10,
            kids = 5,
            novelty = 15
        }

        public Movie(string title, string director, GENRE[] genre, uint length, uint release_year)
        {
            this.title = title;
            this.director = director;
            this.genre = genre;
            this.length = length;
            this.release_year = release_year;
            addTypeToMovie(this);
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

        public void addTypeToMovie(Movie movie)
        {
            for (int i = 0; i < movie.genre.Length; i++)
                if (movie.genre[i] == GENRE.for_kids)
                    movie.price = (int)TYPE.kids;
                else if (movie.release_year == 2016)
                    movie.price = (int)TYPE.novelty;
                else
                    movie.price = (int)TYPE.normal;

        }

        public string getID() { return movie_id; }

        public override string ToString()
        {
            return "Title: " + title + " director: " + director +
                   " genre: " + Genre(genre) + " length: " + length;
        }

    }
}
