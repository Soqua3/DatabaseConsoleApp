using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace DatabaseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.Write("Do you wanna show Customers(1) or Postage company(2)? ");
            string kayttajanVastaus = Console.ReadLine();

           
            string connectionStringWinAuth =
                "Server=LAPTOP-21E2GTUA\\SQLEXVICTORCH;" +
                "Database=Northwind;" +
                "Trusted_Connection=True;"+
                 "User Id=Guest;" +
                "Password=1234;";

           
            Console.WriteLine(connectionStringWinAuth);

            

            SqlConnection conn = new SqlConnection(connectionStringWinAuth);

            conn.Open();
            
            
            if (kayttajanVastaus == "1")
            {
                string sql = "select CompanyName, Country from Customers";
                SqlCommand cmdSelectCustomers = new SqlCommand(sql, conn);

                SqlDataReader reader = cmdSelectCustomers.ExecuteReader();

                Console.WriteLine("Northwinds finnish customers;");
                int xcounter = 0;
                while (reader.Read())
                {
                    if (reader["Country"].ToString() == "Finland")
                    {
                        Console.WriteLine(reader["CompanyName"]);
                        xcounter++;
                    }

                }
                Console.WriteLine("Customers is " + xcounter.ToString());
                reader.Close();
                cmdSelectCustomers.Dispose();
            }
            else if (kayttajanVastaus == "2")
            {
                string sql = "select CompanyName as nimi from Shippers";
                SqlCommand cmdSelectShippers = new SqlCommand(sql, conn);

                SqlDataReader reader = cmdSelectShippers.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["nimi"]);
                }
                reader.Close();
                cmdSelectShippers.Dispose();
            }
            else
            {
                Console.WriteLine("Unfortunately, your input was wrong");
                
            }
  
            conn.Dispose();
            Console.WriteLine("Press enter");
            Console.ReadLine();

        }
    }
}
