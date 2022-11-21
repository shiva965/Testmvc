using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPractice.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int OrderID { get; set; }
        public string OrderName { get; set; }
       
        public DateTime OrderDate { get; set; }

        public int Order_ProductID { get; set; }

    }
}
