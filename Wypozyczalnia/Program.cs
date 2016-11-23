using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//KUBA PYLA GRUPA 33 113995 INFORMATYKA 5 SEM

namespace Wypozyczalnia
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new ClientCard(), "John", "Smith");
            Client client1 = new Client(new ClientCard(), "Steve", "Jobs");
            Client client2 = new Client(new ClientCard(), "Mark", "Zuckerberg");

            Rental ren = new Rental();

            ren.placeOrder(client, null, 0);

            ren.placeOrder(client1, new String[] { "0", "1" }, 5);
            ren.placeOrder(client1, new String[] { "2" }, 3);

            ren.placeOrder(client, new String[] { "3" }, 2);
            ren.placeOrder(client, new String[] { "2" }, 2);

            ren.placeOrder(client2, new String[] { "1" }, 2);

            ren.display(client);
            ren.display(client1);

            Console.ReadKey();
        }
    }
}
