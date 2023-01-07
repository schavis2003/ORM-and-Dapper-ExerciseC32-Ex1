using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductRepository
    {   
        // field that allows us to connect to the database
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name = name, price = price,  categoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");

        }
        public void UpdateProduct(Product product)
        {
            _connection.Execute("Update products" +
                "SET Ma,e = @name, " +
                "Price = @price, " +
                "CategoryID = @categoryId " +
                "OnSale - @onSale " +
                "StockLevel = @stockLevel " +
                "Where ProductID = @id;",

                new
                {
                    id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    categoryID = product.CategoryID,
                    OnSale = product.OnSale,
                    stockLevel = product.StockLevel
                });

        }

        public void DeleteProduct(int id) 
        {
            _connection.Execute("DELETE FROM sales WHERE ProductID = @id", new { id = id });
            _connection.Execute("DELETE FROM reveiws WHERE ProductID = @id", new { id = id });
            _connection.Execute("DELETE FROM product WHERE ProductID = @id", new { id = id });
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
