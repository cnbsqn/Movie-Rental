using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class PrintTXT : Print
    {
        string text = null;
        static int counter = 0;

        public void printConfirmation(Client client, List<ClientMovie> client_movie)
        {
            counter++;
            foreach (ClientMovie rentalInfo in client_movie)
                if (rentalInfo.Client.Card.ID == client.Card.ID)
                {
                    text = counter + ".\r\t" + rentalInfo.ToString() + "\r\n";
                    text += "\r\tYou gain: " + rentalInfo.Client.Card.Points.ToString() + " points\r\n" +
                    "\r\tCost of all rentals: " + rentalInfo.Client.Card.Counted_cost.ToString() + " PLN\r\n";
                }

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "WriteReceipt.txt", text.ToString());
        }
    }
}
