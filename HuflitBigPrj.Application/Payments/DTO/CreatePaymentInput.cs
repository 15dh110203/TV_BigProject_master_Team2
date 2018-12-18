using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Payment.DTO
{
    public class CreatePaymentInput
    {
        public string PaymentNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmt { get; set; }
        public int CustID { get; set; }
        public long UserID { get; set; }

        //public DateTime CreationTime { get; set; }
    }
}