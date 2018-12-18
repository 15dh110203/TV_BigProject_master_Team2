using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public interface ICustomerManager : IDomainService
    {
        IEnumerable<Customer> GetAllList();
        Customer GetCustomerByID(int id);
        Task<Customer> Create(Customer entity);
        void Update(Customer entity);
        void Delete(int id);
    }
}
