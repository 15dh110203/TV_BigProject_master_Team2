using Abp.Application.Services;
using AutoMapper;
using HuflitBigPrj.Inventories.DTO;
using HuflitBigPrj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuflitBigPrj.Inventories
{
    public class InventoryAppService : ApplicationService, IInventoryAppService
    {
        private readonly IInventoryManager _inventoryManager;
        public InventoryAppService(IInventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        public async Task Create(CreateInventoryInput input)
        {
            Inventory output = Mapper.Map<CreateInventoryInput, Inventory>(input);
            await _inventoryManager.Create(output);
        }

        public void Delete(DeleteInventoryInput input)
        {
            _inventoryManager.Delete(input.Id);
        }

        public GetInventoryOutput GetInventoryById(GetInventoryInput input)
        {
            var getInventory = _inventoryManager.GetInventoryByID(input.Id);
            GetInventoryOutput output = Mapper.Map<Inventory, GetInventoryOutput>(getInventory);
            return output;
        }

        public IEnumerable<GetInventoryOutput> ListAll()
        {
            var getAll = _inventoryManager.GetAllList().ToList();
            List<GetInventoryOutput> output = Mapper.Map<List<Inventory>, List<GetInventoryOutput>>(getAll);
            return output;
        }

        public void Update(UpdateInventoryInput input)
        {
            Inventory output = Mapper.Map<UpdateInventoryInput, Inventory>(input);
            _inventoryManager.Update(output);
        }
    }
}