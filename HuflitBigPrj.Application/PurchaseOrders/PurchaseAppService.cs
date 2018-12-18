using Abp.Application.Services;
using AutoMapper;
using HuflitBigPrj.Models;
using HuflitBigPrj.PurchaseOrders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.PurchaseOrders
{
    public class PurchaseAppService: ApplicationService,IPurchaseAppService
    {
        private readonly IPurchaseOrderManager _purchaseOrderManager;

        public PurchaseAppService(IPurchaseOrderManager purchaseOrderManager)
        {
            _purchaseOrderManager = purchaseOrderManager;
        }

        public async Task Create(CreatePurchaseOrderInput input)
        {
            PurchaseOrder output = Mapper.Map<CreatePurchaseOrderInput, PurchaseOrder>(input);
            await _purchaseOrderManager.Create(output);
        }

        public void Delete(DeletePurchaseOrderInput input)
        {
            _purchaseOrderManager.Delete(input.OrderNo);
        }

        public GetPurchaseOrderOutput GetPurchaseOrderByOrderNo(GetPurchaseOrderInput input)
        {
            var GetPurchaseOrder = _purchaseOrderManager.GetPurchaseOrderByOrderNo(input.OrderNo);
            GetPurchaseOrderOutput output = Mapper.Map<PurchaseOrder, GetPurchaseOrderOutput>(GetPurchaseOrder);
            return output;
        }

        public IEnumerable<GetPurchaseOrderOutput> ListAll()
        {
            var getAll = _purchaseOrderManager.GetAllList().ToList();
            List<GetPurchaseOrderOutput> output = Mapper.Map<List<PurchaseOrder>,List< GetPurchaseOrderOutput>>(getAll);
            return output;
        }

        public void Update(UpdatePurchaseOrderInput input)
        {
            PurchaseOrder output = Mapper.Map<UpdatePurchaseOrderInput, PurchaseOrder>(input);
            _purchaseOrderManager.Update(output);
        }
    }
}
