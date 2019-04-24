using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDb = new DataSet("books");

            #region customers
            DataTable customers = new DataTable("Customers");
            customers.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            customers.Columns.Add("name", typeof(string));
            shopDb.Tables.Add(customers);
            #endregion

            #region products
            DataTable products = new DataTable("Products");
            products.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            products.Columns.Add("name", typeof(string));
            shopDb.Tables.Add(products);
            #endregion

            #region employees
            DataTable employees = new DataTable("Employees");
            employees.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            employees.Columns.Add("name", typeof(string));
            shopDb.Tables.Add(employees);
            #endregion

            #region orders
            DataTable orders = new DataTable("Orders");
            orders.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            orders.Columns.Add("productId", typeof(int));
            orders.Columns.Add("customerId", typeof(int));
            shopDb.Tables.Add(orders);
            #endregion

            #region order details
            DataTable orderDetails = new DataTable("OrderDetails");
            orderDetails.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            orderDetails.Columns.Add("orderId", typeof(int));
            orderDetails.Columns.Add("orderDate", typeof(DateTime));
            shopDb.Tables.Add(orderDetails);
            #endregion

            #region relations
            shopDb.Relations.Add("Order_Details_fk",
                shopDb.Tables["Orders"].Columns["id"],
                shopDb.Tables["OrderDetails"].Columns["orderId"]);

            shopDb.Relations.Add("Products_Orders_fk",
                shopDb.Tables["Products"].Columns["id"],
                shopDb.Tables["Orders"].Columns["productId"]);

            shopDb.Relations.Add("Customers_Orders_fk",
                shopDb.Tables["Customers"].Columns["id"],
                shopDb.Tables["Orders"].Columns["customerid"]);
            #endregion

            Console.WriteLine(shopDb.GetXmlSchema());
        }
    }
}
