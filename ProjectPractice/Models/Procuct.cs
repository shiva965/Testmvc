using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectPractice.Models
{
    public partial class Procuct
    {
        public Procuct()
        {
            Orders = new HashSet<Orders>();
        }

        public int Pid { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
