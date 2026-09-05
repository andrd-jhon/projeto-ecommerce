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
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public IQueryable<User> SearchByName(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return GetAll();

            var normalized = search.ToLower().Trim();
            return GetAll().Where(u => u.UserName.ToLower().Contains(normalized));
        }
    }
}
