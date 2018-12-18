using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public interface IPaymentManager : IDomainService
    {
        IEnumerable<Payment> GetAllList();
        Payment GetPaymentByID(int id);
        Task<Payment> Create(Payment entity);
        void Update(Payment entity);
        void Delete(int id);
    }
}
