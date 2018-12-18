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
    public class InventoryManager : DomainService, IInventoryManager
    {
        private readonly IRepository<Inventory> _repositoryInventory;
        public InventoryManager(IRepository<Inventory> repositoryInventory)
        {
            _repositoryInventory = repositoryInventory;
        }

        public async Task<Inventory> Create(Inventory entity)
        {
            var inventory = _repositoryInventory.FirstOrDefault(x => x.InvtID == entity.InvtID);
            if (inventory != null)
            {
                throw new UserFriendlyException("Already exist");
            }
            else
            {
                return await _repositoryInventory.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var inventory = _repositoryInventory.FirstOrDefault(x => x.Id == id);
            if (inventory == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _repositoryInventory.Delete(inventory);
            }
        }

        public IEnumerable<Inventory> GetAllList()
        {
            return _repositoryInventory.GetAll();
        }

        public Inventory GetInventoryByID(int id)
        {
            return _repositoryInventory.Get(id);
        }

        public void Update(Inventory entity)
        {
            _repositoryInventory.Update(entity);
        }
    }
}