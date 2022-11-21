using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using ProjectPractice.Models;

namespace ProjectPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductDetailsController : ControllerBase
    {
        public string connection = "Data Source=DESKTOP-SRDJ1O4\\SQLEXPRESS;Initial Catalog=PracticeProject;Integrated Security=True";

        //[HttpGet]
        //[Route("GetProduct")]
        //public List<ProductViewModel> GetProduct()
        //{
        //    SqlConnection cn = new SqlConnection(connection);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("GetProduct", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    List<ProductViewModel> model = new List<ProductViewModel>();
        //    ProductViewModel item = new ProductViewModel();

        //    while (sdr.Read())
        //    {
        //        item.ProductID = Convert.ToInt32(sdr["Pid"]);
        //        item.ProductName = Convert.ToString(sdr["ProductName"]);
        //        item.Description = Convert.ToString(sdr["Description"]);
        //        item.ProductID = sdr["Pid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Pid"]);
        //        item.ProductName = sdr["ProductName"] == DBNull.Value ? "" : Convert.ToString(sdr["ProductName"]);
        //        item.Description = sdr["Description"] == DBNull.Value ? "" : Convert.ToString(sdr["Description"]);

        //        item.OrderID = Convert.ToInt32(sdr["Oid"]);

        //        item.OrderID = sdr["Oid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Oid"]);
        //        item.OrderName = sdr["OrderName"] == DBNull.Value ? "" : Convert.ToString(sdr["OrderName"]);
        //        item.OrderDate = Convert.ToDateTime(sdr["OrderDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(sdr["OrderDate"]));

        //        item.OrderName = Convert.ToString(sdr["OrderName"]);
        //        item.OrderDate = Convert.ToDateTime(sdr["OrderDate"]);
        //        item.Order_ProductID = Convert.ToInt32(sdr["ProductId"]);
        //        item.Order_ProductID = sdr["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["ProductId"]);
        //        model.Add(item);
        //    }
        //    sdr.Close();
        //    cn.Close();
        //    return model;
        //}

        [HttpGet]
        [Route("GetProductDetails")]
        public List<Procuct>GetProductDetails()
        {
            List<Procuct> product = new List<Procuct>();
            List<Orders> order = new List<Orders>();
            //Procuct model = new Procuct();
            //Orders item = new Orders();
            Procuct model = null;
            Orders item = null;
            int id = 0;
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetProduct", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
             {
                if(id==0||(sdr["ProductId"].Equals(DBNull.Value)?0: Convert.ToInt32(sdr["ProductId"]))!=id)
                {
                    //id = Convert.ToInt32(sdr["Pid"]);
                   id = sdr["ProductId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["ProductId"]);
                    //model.Pid = Convert.ToInt32(sdr["Pid"]);
                    //model.ProductName = sdr["ProductName"].ToString();
                    //model.Description = sdr["Description"].ToString();
                    model = new Procuct();
                    model.Pid = sdr["Pid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Pid"]);
                    model.ProductName = sdr["ProductName"] == DBNull.Value ? "" : Convert.ToString(sdr["ProductName"]);
                    model.Description = sdr["Description"] == DBNull.Value ? "" : Convert.ToString(sdr["Description"]);

                    model.Orders = new List<Orders>();
                    item = new Orders();
                   // item.Oid = Convert.ToInt32(sdr["Oid"]);
                    //item.OrderName = Convert.ToString(sdr["OrderName"]);
                    //item.OrderDate = Convert.ToDateTime(sdr["OrderDate"]);
                    //item.ProductId = Convert.ToInt32(sdr["ProductId"]);

                    item.Oid = sdr["Oid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Oid"]);
                    item.OrderName = sdr["OrderName"] == DBNull.Value ? "" : Convert.ToString(sdr["OrderName"]);

                    item.OrderDate = !String.IsNullOrEmpty(sdr["OrderDate"].ToString()) ? (DateTime?)(sdr["OrderDate"]) : null;
                    item.ProductId = sdr["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["ProductId"]);
                    order.Add(item);
                    //model.Orders.Add(item);
                    model.Orders.Add(item);
                    product.Add(model);
                }
                else
                {
                    item = new Orders();
                    ////item.Oid = Convert.ToInt32(sdr["Oid"]);
                    ////item.OrderName = Convert.ToString(sdr["OrderName"]);
                    ////item.OrderDate = Convert.ToDateTime(sdr["OrderDate"]);

                    ////item.ProductId = Convert.ToInt32(sdr["ProductId"]);
                    item.Oid = sdr["Oid"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(sdr["Oid"]);
                    item.OrderName = sdr["OrderName"] == DBNull.Value ? "" : Convert.ToString(sdr["OrderName"]);

                    item.OrderDate = !String.IsNullOrEmpty(sdr["OrderDate"].ToString()) ? (DateTime?)(sdr["OrderDate"]) : null;
                    item.ProductId = sdr["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(sdr["ProductId"]);
                    model.Orders.Add(item);
                }

            }
            sdr.Close();
            cn.Close();
            return product;
        }
        [HttpPost]
        [Route("UpdateProduct")]
        public Procuct UpdateProduct(Procuct procuct)
        {
           // Procuct procuct = new Procuct();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
           
            SqlCommand cmd = new SqlCommand("Sp_UpdateProduct", cn);

            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Pid", procuct.Pid);
            cmd.Parameters.AddWithValue("@ProductName", procuct.ProductName);
            cmd.Parameters.AddWithValue("@Description", procuct.Description);
            cmd.ExecuteNonQuery();
            cn.Close();
           

            return procuct;
        }
        [HttpGet]
        [Route("GetProcucts")]
        public List<Procuct>GetProcucts()
        {
            List<Procuct> model = new List<Procuct>();
            Procuct procuct = new Procuct();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Sp_selectProduct", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                procuct.Pid = Convert.ToInt32(sdr["Pid"]);
                procuct.ProductName = sdr["ProductName"].ToString();
                procuct.Description = sdr["Description"].ToString();
                
              // procuct.Add()
                //model.Add(procuct);
               // return model;  
            }
            model.Add(procuct);

            sdr.Close();
            cn.Close();
            return model;
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public Procuct DeleteProduct(int?id)
        {
            Procuct procuct = new Procuct();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            SqlCommand cmd = new SqlCommand("Sp_deleteProduct", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Pid", procuct.Pid);
            cmd.Parameters.Add(new SqlParameter("@Pid",id));

            //cmd.Parameters.AddWithValue("@ProductName", procuct.ProductName);
            //cmd.Parameters.AddWithValue("@Description", procuct.Description);
            cmd.ExecuteNonQuery();
            cn.Close();


            return procuct;
        }

        [HttpGet]
        [Route("getProduct")]
        public List<Procuct> getProduct()
        {
            List<Procuct> model = new List<Procuct>();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Sp_selectProduct", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable ds = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter(cmd);
            Sda.Fill(ds);
            if(ds.Rows.Count>0)
            {
                for (int i = 0; i < ds.Rows.Count;i++)
                {
                    Procuct procuct = new Procuct();
                    procuct.Pid = Convert.ToInt32(ds.Rows[i]["Pid"]);
                    procuct.ProductName = ds.Rows[i]["ProductName"].ToString();
                    procuct.Description = ds.Rows[i]["Description"].ToString();
                    model.Add(procuct);
                      
                }
            }

          
            cn.Close();
            return model;

        }

        [HttpGet]
        [Route("SelectWhereProduct")]
        public Procuct SelectWhereProduct(int?id)
        {
            //shiva//
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Sp_selectWHereProduct", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@Pid", id);
            sda.Fill(dt);
            Procuct item = new Procuct();

            if(dt.Rows.Count>0)
            {
                item.Pid = Convert.ToInt32(dt.Rows[0]["Pid"]);
                item.ProductName = dt.Rows[0]["ProductName"].ToString();
                item.Description = dt.Rows[0]["Description"].ToString();
            }
            return item;
        }

    }
}
