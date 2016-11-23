using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Client
    {
        public Client(ClientCard card, string name, string surname)
        {
            this.card = card;
            this.card.ID = (counter.ToString() + name[0] + surname[0]).ToUpper();
            this.name = name;
            this.surname = surname;
            counter++;
        }

        static int counter = 0;
        ClientCard card;
        private string name;
        private string surname;

        public ClientCard Card
        {
            get { return card; }
        }

        public void display()
        {
            Console.Write(name + " " + surname + " " + card.ID);
        }

        public override string ToString()
        {
            return "Name: " + name + " Surname: " + surname +
                   " card ID: " + card.ID.ToString();
        }

    }
}
