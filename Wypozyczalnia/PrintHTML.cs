using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class PrintHTML : Print
    {
        string text = "";
        static int counter = 0;
        public void printConfirmation(Client client, List<ClientMovie> client_movie)
        {
            counter++;

            if (!this.text.Contains("<!DOCTYPE HTML>"))
            {
                text += "<!DOCTYPE HTML ><html lang =pl><head><meta charset = \"utf-8\" /><meta http - equiv = \"X-UA-Compatible\" content = \"IE=edge,chrome=1\" /><title> MOVIE RENTAL </title><meta name = \"description\" content = \"Movie rental\" /><meta name = \"keywords\" content = \"rental, movie, movies\" /><link rel = \"stylesheet\" type = \"text/css\" href = \"style'\'style.css\" media = \"all\"></ head><body >";
            }

            foreach (ClientMovie rentalInfo in client_movie)
                if (rentalInfo.Client.Card.ID == client.Card.ID)
                {

                    text += counter + ".\r\t" + rentalInfo.ToString() + "\r\n";
                    text += "\r\tYou gain: " + rentalInfo.Client.Card.Points.ToString() + " points\r\n" +
                            "\r\tCost of all rentals: " + rentalInfo.Client.Card.Counted_cost.ToString() + " PLN\r\n";
                }

            text += "</body >";
            text += "</html >";

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Rental" + client.Card.ID + ".html", text);
        }
    }
}
