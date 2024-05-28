using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Commands
{
    public class CategoryCommand : IRequest<Category>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
