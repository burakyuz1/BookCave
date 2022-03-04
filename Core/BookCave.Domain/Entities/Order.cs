﻿using BookCave.Domain.Abstracts;
using BookCave.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace BookCave.Domain.Entities
{
    public class Order : BaseEntity,IEntity
    {
        //TODO: USER BAĞLANTISI
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}