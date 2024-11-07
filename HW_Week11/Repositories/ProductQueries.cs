using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week11.Repositories
{
    public static class ProductQueries
    {
        public static string Create = "insert into Products (Name , CategoryId , Price) values (@Name , @CategoryId , @Price)";
        public static string Get = " SELECT p.Id, p.Name AS Name, c.Name AS CategoryName, p.Price  FROM Products p JOIN Categories c ON p.CategoryId = c.Id WHERE p.Id = @Id";
        public static string GetAll = "SELECT p.Id, p.Name AS Name, c.Name AS CategoryName, p.Price FROM Products p JOIN Categories c ON p.CategoryId = c.Id";
        public static string Delete = "DELETE FROM Products WHERE Id = @Id";
        public static string Update = "UPDATE Products SET Name = @Name, CategoryId = @CategoryId, Price = @Price WHERE Id = @Id";

    }
}
