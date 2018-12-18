using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public class PurchaseOrder : FullAuditedEntity
    {
        [Key]
        [Display(Name = "Số")]
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; }
        public DateTime OverdueDate { get; set; }

        public decimal DiscAmt { get; set; }
        public decimal PromAmt { get; set; }
        public decimal ComAmt { get; set; }
        public decimal TaxtAmt { get; set; }
        public decimal TotalAmt { get; set; }

        public virtual ICollection<PurchaseOrdDetail> Purchases { get; set; }
    }
}
