using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new ClientCard(), "Jakub", "Pyla");
            Client client1 = new Client(new ClientCard(), "Marcin", "Uryga");
            Client client2 = new Client(new ClientCard(), "Michal", "Sroka");

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
