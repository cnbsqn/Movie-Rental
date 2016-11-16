using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class ClientMovie
    {
        private List<Movie> client_movies = new List<Movie>();

        private Client client;

        public ClientMovie(Client client)
        {
            this.client = client;
        }

        public ClientMovie(Client client, List<Movie> client_movies)
        {
            this.client = client;
            this.client_movies = client_movies;
        }

        public void addMovie(Movie movie, uint days)
        {
            client_movies.Add(movie);
            client.Card.Points += client.Card.addPoints(movie.Price, days);
            client.Card.Counted_cost += (movie.Price + days);
        }

        public Client Client
        {
            get { return client; }
        }

        public List<Movie> get_client_movies()
        {
            return client_movies;
        }

        public void display()
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("\nClient data:");
            client.display();
            Console.WriteLine("\nRented movies:");
            if (client_movies != null)
            {
                foreach (Movie movie in client_movies)
                    Console.WriteLine(movie.ToString());
            }
            else Console.WriteLine("\nNo rented movies.");
        }
    }
}
