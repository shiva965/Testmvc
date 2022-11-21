using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPracticeMvc.Models
{
    public class Orders
    {
        public int Oid { get; set; }
        public string OrderName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ProductId { get; set; }

       // public virtual Procuct Product { get; set; }
    }
}
