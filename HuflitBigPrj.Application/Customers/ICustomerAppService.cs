using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Customer.DTO
{
    public interface ICustomerAppService : IApplicationService
    {
        IEnumerable<GetCustomerOutput> ListAll();
        Task Create(CreateCustomerInput input);
        void Update(UpdateCustomerInput input);
        void Delete(DeleteCustomerInput input);
        GetCustomerOutput GetCustomerById(GetCustomerInput input);
    }
}