﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Inventories.DTO
{
    public class UpdateInventoryInput
    {
        public int Id { get; set; }
        public int InvtID { get; set; }
        public string InvtName { get; set; }
        public int QtyStock { get; set; }
    }
}