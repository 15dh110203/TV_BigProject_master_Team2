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
    public class PurchaseOrderManager:DomainService,IPurchaseOrderManager
    {
        private readonly IRepository<PurchaseOrder> _repositoryPurchaseOrder;
        public PurchaseOrderManager(IRepository<PurchaseOrder> repositoryPurchaseOrder)
        {
            _repositoryPurchaseOrder = repositoryPurchaseOrder;
        }

        public async Task<PurchaseOrder> Create(PurchaseOrder entity)
        {
            var purchaseOrder = _repositoryPurchaseOrder.FirstOrDefault(x => x.OrderNo == entity.OrderNo);
            if(purchaseOrder != null)
            {
                throw new UserFriendlyException("Already exist");
            }
            else
            {
                return await _repositoryPurchaseOrder.InsertAsync(entity);
            }
        }

        public void Delete(int orderNo)
        {
            var purchaseOrder = _repositoryPurchaseOrder.FirstOrDefault(x => x.OrderNo == orderNo);
            if(purchaseOrder == null)
            {
                throw new UserFriendlyException("Already exist");
            }
            else
            {
                _repositoryPurchaseOrder.Delete(purchaseOrder);
            }
        }

        public IEnumerable<PurchaseOrder> GetAllList()
        {
            return _repositoryPurchaseOrder.GetAll();
        }

        public PurchaseOrder GetPurchaseOrderByOrderNo(int orderNo)
        {
            return _repositoryPurchaseOrder.Get(orderNo);
        }

        public void Update(PurchaseOrder entity)
        {
            _repositoryPurchaseOrder.Update(entity);
        }
    }
}
