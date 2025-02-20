using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducer
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
