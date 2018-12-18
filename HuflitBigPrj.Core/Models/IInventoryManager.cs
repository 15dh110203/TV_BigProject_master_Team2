using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Models
{
    public interface IInventoryManager : IDomainService
    {
        IEnumerable<Inventory> GetAllList();
        Inventory GetInventoryByID(int id);
        Task<Inventory> Create(Inventory entity);
        void Update(Inventory entity);
        void Delete(int id);
    }
}
