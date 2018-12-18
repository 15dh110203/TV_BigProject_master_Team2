using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public class PaymentManager : DomainService, IPaymentManager
    {
        private readonly IRepository<Payment> _repositoryPayment;
        public PaymentManager(IRepository<Payment> repositoryPayment)
        {
            _repositoryPayment = repositoryPayment;
        }

        public async Task<Payment> Create(Payment entity)
        {
            var payment = _repositoryPayment.FirstOrDefault(x => x.PaymentID == entity.PaymentID);
            if (payment != null)
            {
                throw new UserFriendlyException("Already Exist");
            }
            else
            {
                return await _repositoryPayment.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var payment = _repositoryPayment.FirstOrDefault(x => x.PaymentID == id);
            if (payment == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _repositoryPayment.Delete(payment);
            }
        }

        public IEnumerable<Payment> GetAllList()
        {
            return _repositoryPayment.GetAll();
        }

        public Payment GetPaymentByID(int id)
        {
            return _repositoryPayment.Get(id);
        }

        public void Update(Payment entity)
        {
            _repositoryPayment.Update(entity);
        }
    }
}
