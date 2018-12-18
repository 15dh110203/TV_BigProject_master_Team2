using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public class PurchaseOrdDetail : FullAuditedEntity
    {
        public int Qty { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal QtyProm { get; set; }
        public decimal QtyPromAmt { get; set; }
        public decimal AmtProm { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Amount { get; set; }

        [Required]
        [ForeignKey("PurchaseOrder")]
        public int OrderNo { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [ForeignKey("Stock")]
        public int StockNo { get; set; }
        public virtual Stock Stock { get; set; }

        [ForeignKey("Inventory")]
        public int InvtID { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
