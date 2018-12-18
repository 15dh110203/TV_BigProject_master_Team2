using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Inventories.DTO
{
    public class CreateInventoryInput
    {
        public string InvtName { get; set; }
        public int QtyStock { get; set; }
    }
}