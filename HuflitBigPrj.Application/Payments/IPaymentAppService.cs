using Abp.Application.Services;
using HuflitBigPrj.Payment.DTO;
using HuflitBigPrj.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Payment
{
    public interface IPaymentAppService : IApplicationService
    {
        IEnumerable<GetPaymentOutput> ListAll();
        Task Create(CreatePaymentInput input);
        void Update(UpdatePaymentInput input);
        void Delete(DeletePaymentInput input);
        GetPaymentOutput GetPaymentById(GetPaymentInput input);
    }
}