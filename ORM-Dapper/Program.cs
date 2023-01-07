using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);


            #region Department
            var departmentRepo = new DapperDepartmentRepository(conn);  // Created instance using custom constructor

            departmentRepo.InsertDepartment("Angler Department");  // used this instance to call our method
            var allDepartments = departmentRepo.GetAllDepartments();  // used this instance to call out method

            foreach (Department item in allDepartments) // iteratated through our collection
            {
                Console.WriteLine($"Department ID:  {item.DepartmentID}");
                Console.WriteLine($"Department Name:  {item.Name}");

            }
            #endregion 


            #region Product
            var productRepo = new DapperProductRepository(conn);
            productRepo.CreateProduct("Fishing Rod", 39.99, 10);
            var allProducts = productRepo.GetAllProducts();

            foreach (var item in allProducts)
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"{item.Price}");
                Console.WriteLine($"{item.CategoryID}");
            }

            #endregion


            
        }   
            
    }
}
