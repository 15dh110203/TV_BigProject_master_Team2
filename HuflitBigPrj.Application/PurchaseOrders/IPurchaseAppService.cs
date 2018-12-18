using Abp.Application.Services;
using HuflitBigPrj.PurchaseOrders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.PurchaseOrders
{
    public interface IPurchaseAppService : IApplicationService
    {
        IEnumerable<GetPurchaseOrderOutput> ListAll();
        Task Create(CreatePurchaseOrderInput input);
        void Update(UpdatePurchaseOrderInput input);
        void Delete(DeletePurchaseOrderInput input);
        GetPurchaseOrderOutput GetPurchaseOrderByOrderNo(GetPurchaseOrderInput input);
    }
}
