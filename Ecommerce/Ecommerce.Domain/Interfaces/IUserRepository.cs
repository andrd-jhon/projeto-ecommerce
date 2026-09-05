using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        IQueryable<User> SearchByName(string? search);

    }
}
