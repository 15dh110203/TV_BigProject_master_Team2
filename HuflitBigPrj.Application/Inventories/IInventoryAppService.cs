using Abp.Application.Services;
using HuflitBigPrj.Inventories;
using HuflitBigPrj.Inventories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Inventories
{
    public interface IInventoryAppService : IApplicationService
    {
        IEnumerable<GetInventoryOutput> ListAll();
        Task Create(CreateInventoryInput input);
        void Update(UpdateInventoryInput input);
        void Delete(DeleteInventoryInput input);
        GetInventoryOutput GetInventoryById(GetInventoryInput input);
    }
}