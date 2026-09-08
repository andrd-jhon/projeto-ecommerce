using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Common.Sorting
{
    public interface ISortingApplier
    {
        public IQueryable<T> Apply<T>(IQueryable<T> query, SortingParameters parameters, SortDefinition<T> definition);
    }
}
