using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Payment.DTO
{
    public class GetPaymentOutput
    {
        public int PaymentID { get; set; }

        //public int Id { get; set; }
        public string PaymentNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustID { get; set; }
        public string CustName { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
        public decimal PaymentAmt { get; set; }
    }
}