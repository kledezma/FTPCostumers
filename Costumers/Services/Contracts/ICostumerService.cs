using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Costumers.Services.Contracts
{
    public interface ICostumerService
    {
        string GetName();

        int DeleteCostumer(int IDCostumer);

        int AddCostumer(Costumer NewCostumer);

        List<Costumer> GetListCostumer(string name, string phone, string email, string notes);
    }
}
