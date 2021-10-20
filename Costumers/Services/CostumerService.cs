using Costumers.Services.Contracts;
using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Costumers.Services
{
    public class CostumerService : ICostumerService
    {
        protected string Conn { get; set; }
        public CostumerService() {

            this.Conn = @"Data Source=DESKTOP-SI51I1J\SQLEXPRESS;Initial Catalog=db;Integrated Security=SSPI;";

        }

      public string GetName()
        {
            return "Marito Maracus";
        }

        public int DeleteCostumer(int IDCostumer)
        {
            try
            {
                using (var db = new SqlConnection(this.Conn))
                {

                    string queryInsert = "Delete from Costumer where IDCostumer = @IDCostumer";
                    var resultado = db.Execute(queryInsert, new { IDCostumer = IDCostumer });
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int AddCostumer(Costumer NewCostumer)
        {
            try
            {
                using (var db = new SqlConnection(this.Conn))
                {

                    string queryInsert = "Insert into Costumer(IDCostumer,Name,Phone,Email,Notes) Values (@IDCostumer,@Name,@Phone,@Email,@Notes)";
                    var resultado = db.Execute(queryInsert, new { IDCostumer = NewCostumer.IDCostumer, Name = NewCostumer.Name, Phone = NewCostumer.Phone, Email = NewCostumer.Email, Notes = NewCostumer.Notes });
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
       

        }

        public List<Costumer> GetListCostumer(string name, string phone, string email, string notes)
        {
            List<Costumer> ListaCostumers = new List<Costumer>();
            

            using (var db = new SqlConnection(this.Conn))
            {
                string queryGetList = "";

                if ((name != null && name != "") || (phone != null && phone != "") || (email != null && email != "") || (notes != null && notes != ""))
                {
                    queryGetList = "Select IDCostumer,Name,Phone,Email,Notes From Costumer Where Name = @Name OR Phone= @Phone OR Email = @Email OR Notes = @Notes ORDER BY IDCostumer ";
                    ListaCostumers = db.Query<Costumer>(queryGetList,new { Name = name, Phone = phone, Email = email, Notes = notes }).ToList();
                }
                else
                {
                    queryGetList = "Select IDCostumer,Name,Phone,Email,Notes from Costumer ORDER BY IDCostumer";
                    ListaCostumers = db.Query<Costumer>(queryGetList).ToList();
                }
            }
            return ListaCostumers;
        }

    }
}
