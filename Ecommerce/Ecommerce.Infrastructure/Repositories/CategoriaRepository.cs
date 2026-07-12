using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoriaRepository: Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository (ApplicationDbContext context) : base(context) { }
    }
}
