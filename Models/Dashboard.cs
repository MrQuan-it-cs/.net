using frmDangKy_va_frmSanPham.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmDangKy_va_frmSanPham.Models
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class Dashboard: DbConnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProducts { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }

        public int NumOrders { get; set; }
        public int NumPurchases { get; set; }
        public decimal TotalRevenue { get; set; }
        public Dashboard() {

        }
        private void GetNumberItems()
        {
            using(var connection = GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "select count(CustomerID) from Customers";
                    NumCustomers = (int)command.ExecuteScalar();

                    command.CommandText = "select count(ProductID) from Products";
                    NumProducts = (int)command.ExecuteScalar();

                    command.CommandText = @"select count(OrderID) from Orders where OrderDate between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();

                    //command.CommandText = @"select count(PurchaseID) from Purchases where PurchaseDate between @fromDate and @toDate";
                    //command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    //command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    //NumPurchases = (int)command.ExecuteScalar();
                }
            }
        }
        private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalRevenue = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = @"select OrderDate, sum(Quantity*UnitCost) from OrderDetails, Orders where OrderDetails.OrderID =  Orders.OrderID and OrderDate between @fromDate and @toDate group by OrderDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;

                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime,decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1]));
                        TotalRevenue += (decimal)reader[1];
                    }
                    reader.Close();

                    if(numberDays <= 30)
                    {
                        foreach (var item in resultTable)
                        {
                            GrossRevenueList.Add(new RevenueByDate()
                            {
                                Date = item.Key.ToString("dd MMM"),
                                TotalAmount = item.Value
                            });
                        }
                    }
                    else if(numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key,CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    else if (numberDays <= (365 * 2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Years
                    else
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }
            }
        }
        private void GetProductAnalisys()
        {
            TopProducts = new List<KeyValuePair<string, int>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = @"select top 5 P.ProductName, sum(OrderDetails.Quantity) as Q from OrderDetails inner join Products P on P.ProductID = OrderDetails.ProductID inner join Orders O on O.OrderID = OrderDetails.OrderID where OrderDate between @fromDate and @toDate group by P.ProductName order by Q desc";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopProducts.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
        }
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate= new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute,59);
            if(startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate- startDate).Days;

                GetNumberItems();
                GetOrderAnalisys();
                GetProductAnalisys();

                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
