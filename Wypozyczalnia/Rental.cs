using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Rental
    {
        public Rental()
        {
            addMovieToRent("Star Wars VII", "J.J. Abrams", new Movie.GENRE[] { Movie.GENRE.adventure, Movie.GENRE.scifi }, 135, 2015);
            addMovieToRent("Doctor Strange", "Scott Derrickson", new Movie.GENRE[] { Movie.GENRE.fantasy, Movie.GENRE.adventure }, 115, 2016);
            addMovieToRent("The Shawshank Redemption", "Frank Darabont", new Movie.GENRE[] { Movie.GENRE.drama}, 132, 1994);
        }

        private List<ClientMovie> client_movie = new List<ClientMovie>();
        private Dictionary<Movie, bool> movies_in_rental = new Dictionary<Movie, bool>();

        public void addMovieToRent(string title, string director, Movie.GENRE[] genre, uint length, uint release_year)
        {
            movies_in_rental.Add(new Movie(title, director, genre, length, release_year), true);

        }

        public void MovieNotAvailable(string movie_id)
        {
            foreach (KeyValuePair<Movie, bool> pair in movies_in_rental)
                if (String.Equals(movie_id, pair.Key.getID()))
                    RenameKey(movies_in_rental, pair.Key, false);
        }

        public void MovieAvailable(string movie_id)
        {
            foreach (KeyValuePair<Movie, bool> pair in movies_in_rental)
                if (String.Equals(movie_id, pair.Key.getID()))
                    RenameKey(movies_in_rental, pair.Key, true);
        }

        public static void RenameKey<TKey,TValue>(IDictionary<TKey,TValue> dic, TKey Key, TValue toValue)
        {
            dic[Key] = toValue;
        }

        public void deleteMovieFromClientList(Client client, Movie movie)
        {
            foreach (ClientMovie current in client_movie)
                foreach (Movie current2 in current.get_client_movies())
                    if (String.Equals(movie.getID(), current2.getID()))
                        current.get_client_movies().Remove(current2);
        }

        public void AvailableMovies()
        {
            Console.WriteLine("\n\nMOVIES AVAILABLE IN RENTAL:");
            foreach (KeyValuePair<Movie, bool> pair in movies_in_rental)
                Console.WriteLine(pair.Key.ToString());
        }

        public void CustomerService(Client client)
        {
            if (client_movie.Count == 0)
            {
                Console.WriteLine("\n");
                client.display();
                Console.WriteLine("\nYou are the first client in our movie rental.");
                client_movie.Add(new ClientMovie(client));
                Console.Write("\nAdded: ");
                client.display();
                Console.Write(" to client database.");
            }
            else if (client_movie.Count > 0)
            {
                bool isClient = false;
                foreach (ClientMovie client_list in client_movie)
                {
                    if (client_list.Client.Card.ID == client.Card.ID)
                    {
                        client.display();
                        Console.WriteLine("\nYou already have a card in our database.");
                        isClient = true;
                    }
                }
                if (!isClient)
                {
                    client_movie.Add(new ClientMovie(client));
                    Console.Write("\nAdded: ");
                    client.display();
                    Console.Write(" to client database.");
                }
            }
        }

        public void RentAMovie(Client client, String[] keyIDMovie, uint days)
        {
            if (client!=null && keyIDMovie !=null)
                foreach (ClientMovie client_rents in client_movie)
                    if (client_rents.Client.Card.ID==client.Card.ID)
                        foreach (String movie_id in keyIDMovie)
                            foreach (KeyValuePair<Movie,bool> pair in movies_in_rental)
                            {
                                if (movie_id == pair.Key.getID())
                                {
                                    client_rents.addMovie(pair.Key, days);
                                }
                            }
        }

        public void placeOrder(Client client, String[] keyIDMovie, uint days)
        {
            AvailableMovies();
            CustomerService(client);
            RentAMovie(client, keyIDMovie, days);
        }

        public void display(Client client)
        {
            foreach (ClientMovie RentalInfo in client_movie)
                if (RentalInfo.Client.Card.ID == client.Card.ID)
                {
                    RentalInfo.display();

                    Console.Write("\nYou gain: ");
                    Console.Write(RentalInfo.Client.Card.Points);
                    Console.WriteLine(" points");
                    Console.Write("Cost of all rentals: ");
                    Console.Write(RentalInfo.Client.Card.Counted_cost);
                    Console.WriteLine(" PLN");
                }
        }
    }
}
