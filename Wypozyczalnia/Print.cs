using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    interface Print
    {
        void printConfirmation(Client client, List<ClientMovie> client_movie);
    }
}
