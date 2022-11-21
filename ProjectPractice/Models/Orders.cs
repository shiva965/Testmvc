using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectPractice.Models
{
    public partial class Orders
    {
        public int Oid { get; set; }
        public string OrderName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ProductId { get; set; }

        public virtual Procuct Product { get; set; }
    }
}
