using Abp.Application.Services;
using AutoMapper;
using HuflitBigPrj.Models;
using HuflitBigPrj.Payment;
using HuflitBigPrj.Payment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Payments
{
    public class PaymentAppService : ApplicationService, IPaymentAppService
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentAppService(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        public async Task Create(CreatePaymentInput input)
        {
            Models.Payment output = Mapper.Map<CreatePaymentInput, Models.Payment>(input);
            await _paymentManager.Create(output);
        }

        public void Delete(DeletePaymentInput input)
        {
            _paymentManager.Delete(input.PaymentID);
        }

        public GetPaymentOutput GetPaymentById(GetPaymentInput input)
        {
            var getPayment = _paymentManager.GetPaymentByID(input.PaymentID);
            GetPaymentOutput output = Mapper.Map<Models.Payment, GetPaymentOutput>(getPayment);
            return output;
        }

        public IEnumerable<GetPaymentOutput> ListAll()
        {
            var output = _paymentManager.GetAllList().Select(x => new GetPaymentOutput
            {
                PaymentID = x.PaymentID,
                PaymentNo = x.PaymentNo,
                PaymentDate = x.PaymentDate,
                CustID = x.CustID,
                CustName = x.Customer.CustName,
                UserID = x.User.Id,
                UserName = x.User.UserName,
                PaymentAmt = x.PaymentAmt
            }).ToList();
            //List<GetPaymentOutput> output = Mapper.Map<List<Models.Payment>,List<GetPaymentOutput>>(getAll);
            return output;
        }

        public void Update(UpdatePaymentInput input)
        {
            Models.Payment output = Mapper.Map<UpdatePaymentInput, Models.Payment>(input);
            _paymentManager.Update(output);
        }
    }
}