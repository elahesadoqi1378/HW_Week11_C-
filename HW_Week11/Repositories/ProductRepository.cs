using HW_Week11.Contracts;
using HW_Week11.Entities;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week11.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Create(Product product)
        {
            
                using (IDbConnection db = new SqlConnection(Configuration.Configuration.ConnectionString))
                {
                    db.Execute(ProductQueries.Create, new { Name = product.Name , CategoryId = product.CategoryId, price = product.Price });
                }
            
        }
        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.ConnectionString))
            {
                return db.QueryFirstOrDefault<Product>(ProductQueries.Get, new { Id = id });
            }
        }
        public List<Product> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.ConnectionString))
            {
                return db.Query<Product>(ProductQueries.GetAll).ToList();
            }
        }
        public void Update(Product p )
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.ConnectionString))
            {
                db.Execute("UPDATE Products SET Name = @Name, CategoryId = @CategoryId, Price = @Price WHERE Id = @Id",
                    new { Id = p.Id ,  Name = p.Name, CategoryId = p.CategoryId  , Price = p.Price});

            }
            ;
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.ConnectionString))
            {
                db.Execute(ProductQueries.Delete, new { Id = id });
            }
        }

       

       
       
    }
}
