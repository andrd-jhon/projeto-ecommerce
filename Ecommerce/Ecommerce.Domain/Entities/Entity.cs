using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Entity
    {
        public int Id { get; protected set; }
        public bool Ativo { get; set; }
    }
}
