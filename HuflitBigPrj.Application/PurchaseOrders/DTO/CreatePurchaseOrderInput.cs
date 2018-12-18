using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.PurchaseOrders.DTO
{
    public class CreatePurchaseOrderInput
    {
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; }
        public DateTime OverdueDate { get; set; }

        public decimal DiscAmt { get; set; }
        public decimal PromAmt { get; set; }
        public decimal ComAmt { get; set; }
        public decimal TaxtAmt { get; set; }
        public decimal TotalAmt { get; set; }
    }
}
