﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class OrderDetail : BaseEntity
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; } //İlgili üründen kaç adet alındı

        //Relational Properties

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

    }
}
