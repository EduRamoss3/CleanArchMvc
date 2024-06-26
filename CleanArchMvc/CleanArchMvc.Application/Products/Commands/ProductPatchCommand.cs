﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Commands
{
    public class ProductPatchCommand : ProductCommand
    {
        public int Id { get; set; }
        public ProductPatchCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }   
    }
}
