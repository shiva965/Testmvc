using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectPractice.Models;
using ProjectPractice.Repository;

namespace ProjectPractice.Repository
{
    public class PostRepository
    {
        public string connection= "Data Source=DESKTOP-SRDJ1O4\\SQLEXPRESS;Initial Catalog=PracticeProject;Integrated Security=True";
        //public  Task<List<Procuct>>GetProducts()
        //{
        //    //using(SqlConnection cn=new SqlConnection(connection))
        //    //{
        //    //    using (SqlCommand cmd=new SqlCommand("GetProduct", cn))
        //    //    {
        //    //        cmd.CommandType = CommandType.StoredProcedure;


        //    //    }

        //    //}
        //    List<Procuct> product = new List<Procuct>();
        //    List<Orders> order = new List<Orders>();
        //    //Procuct model = new Procuct();
        //    //Orders item = new Orders();
        //    Procuct model = null;
        //    Orders item = null;
        //    int id = 0;
        //    SqlConnection cn = new SqlConnection(connection);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("GetProduct", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        if (id == 0 || (sdr["ProductId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["ProductId"])) != id)
        //        {
        //            //id = Convert.ToInt32(sdr["Pid"]);
        //            id = sdr["ProductId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["ProductId"]);
        //            //model.Pid = Convert.ToInt32(sdr["Pid"]);
        //            //model.ProductName = sdr["ProductName"].ToString();
        //            //model.Description = sdr["Description"].ToString();
        //            model = new Procuct();
        //            model.Pid = sdr["Pid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Pid"]);
        //            model.ProductName = sdr["ProductName"] == DBNull.Value ? "" : Convert.ToString(sdr["ProductName"]);
        //            model.Description = sdr["Description"] == DBNull.Value ? "" : Convert.ToString(sdr["Description"]);

        //            model.Orders = new List<Orders>();
        //            item = new Orders();
        //            // item.Oid = Convert.ToInt32(sdr["Oid"]);
        //            //item.OrderName = Convert.ToString(sdr["OrderName"]);
        //            //item.OrderDate = Convert.ToDateTime(sdr["OrderDate"]);
        //            //item.ProductId = Convert.ToInt32(sdr["ProductId"]);

        //            item.Oid = sdr["Oid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Oid"]);
        //            item.OrderName = sdr["OrderName"] == DBNull.Value ? "" : Convert.ToString(sdr["OrderName"]);

        //            item.OrderDate = !String.IsNullOrEmpty(sdr["OrderDate"].ToString()) ? (DateTime?)(sdr["OrderDate"]) : null;
        //            item.ProductId = sdr["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["ProductId"]);
        //            order.Add(item);
        //            //model.Orders.Add(item);
        //            model.Orders.Add(item);
        //            product.Add(model);
        //        }
        //        else
        //        {
        //            item = new Orders();
        //            ////item.Oid = Convert.ToInt32(sdr["Oid"]);
        //            ////item.OrderName = Convert.ToString(sdr["OrderName"]);
        //            ////item.OrderDate = Convert.ToDateTime(sdr["OrderDate"]);

        //            ////item.ProductId = Convert.ToInt32(sdr["ProductId"]);
        //            item.Oid = sdr["Oid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Oid"]);
        //            item.OrderName = sdr["OrderName"] == DBNull.Value ? "" : Convert.ToString(sdr["OrderName"]);

        //            item.OrderDate = !String.IsNullOrEmpty(sdr["OrderDate"].ToString()) ? (DateTime?)(sdr["OrderDate"]) : null;
        //            item.ProductId = sdr["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["ProductId"]);
        //            model.Orders.Add(item);
        //        }

        //    }
        //    sdr.Close();
        //    cn.Close();
        //    return product;
        //}
    }
}
