using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public interface IPurchaseOrderManager:IDomainService
    {
        IEnumerable<PurchaseOrder> GetAllList();
        PurchaseOrder GetPurchaseOrderByOrderNo(int orderNo);
        Task<PurchaseOrder> Create(PurchaseOrder entity);
        void Update(PurchaseOrder entity);
        void Delete(int orderNo);
    }
}
