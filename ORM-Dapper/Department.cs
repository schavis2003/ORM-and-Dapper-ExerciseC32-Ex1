using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class Department  //table Name in MySql
    {
        public int DepartmentID { get; set; }  //Column Name in MySql

        public string Name { get; set; }  // Column Name in MySql
    }
}
