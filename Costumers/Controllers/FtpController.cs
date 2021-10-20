using Costumers.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Costumers.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FtpController : Controller
    {
        private readonly ICostumerService _costumerService;
        public FtpController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }

      

        [HttpGet]
        public IEnumerable<Costumer> GetListCostumer(string name, string phone, string email, string notes)
        {
            return _costumerService.GetListCostumer(name,phone,email,notes).ToArray();
        }


        [HttpPost]
        public int AddUser(Costumer NewCostumer)
        {
           int response = _costumerService.AddCostumer(NewCostumer);
           return response;
         }

        [HttpDelete("{Id:int}")]

        public int DeleteCostumer(int Id) {

            int response = _costumerService.DeleteCostumer(Id);
            return response;
        } 

    }
}
