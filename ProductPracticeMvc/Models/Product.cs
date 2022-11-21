
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPracticeMvc.Models
{
    public class Product
    {
        //public Procuct()
        //{
        //    Orders = new HashSet<Orders>();
        //}

        public int Pid { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public int Oid { get; set; }
        public string OrderName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ProductId { get; set; }
    }
}
