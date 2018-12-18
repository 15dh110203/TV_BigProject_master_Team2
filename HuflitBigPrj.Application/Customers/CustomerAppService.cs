using Abp.Application.Services;
using AutoMapper;
using HuflitBigPrj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuflitBigPrj.Customer.DTO
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly ICustomerManager _customerManager;
        public CustomerAppService(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public async Task Create(CreateCustomerInput input)
        {
            Models.Customer output = Mapper.Map<CreateCustomerInput, Models.Customer>(input);
            await _customerManager.Create(output);
        }

        public void Delete(DeleteCustomerInput input)
        {
            _customerManager.Delete(input.CustID);
        }

        public GetCustomerOutput GetCustomerById(GetCustomerInput input)
        {
            var getCustomer = _customerManager.GetCustomerByID(input.CustID);
            GetCustomerOutput output = Mapper.Map<Models.Customer, GetCustomerOutput>(getCustomer);
            return output;
        }

        public IEnumerable<GetCustomerOutput> ListAll()
        {
            var getAll = _customerManager.GetAllList().ToList();
            List<GetCustomerOutput> output = Mapper.Map<List<Models.Customer>, List<GetCustomerOutput>>(getAll);
            return output;
        }

        public void Update(UpdateCustomerInput input)
        {
            Models.Customer output = Mapper.Map<UpdateCustomerInput, Models.Customer>(input);
            _customerManager.Update(output);
        }
    }
}