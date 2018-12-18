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
    public class CustomerManager : DomainService, ICustomerManager
    {
        private readonly IRepository<Customer> _repositoryCustomer;
        public CustomerManager(IRepository<Customer> repositoryCustomer)
        {
            _repositoryCustomer = repositoryCustomer;
        }

        public async Task<Customer> Create(Customer entity)
        {
            var customer = _repositoryCustomer.FirstOrDefault(x => x.Id == entity.Id);
            if (customer != null)
            {
                throw new UserFriendlyException("Already Exist");
            }
            else
            {
                return await _repositoryCustomer.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var customer = _repositoryCustomer.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _repositoryCustomer.Delete(customer);
            }
        }

        public IEnumerable<Customer> GetAllList()
        {
            return _repositoryCustomer.GetAll();
        }

        public Customer GetCustomerByID(int id)
        {
            return _repositoryCustomer.Get(id);
        }

        public void Update(Customer entity)
        {
            _repositoryCustomer.Update(entity);
        }
    }
}