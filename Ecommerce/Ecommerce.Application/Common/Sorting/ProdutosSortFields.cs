using System.Linq.Expressions;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Sorting;

public static class ProdutoSortFields
{
    public static readonly SortDefinition<Produto> Definition =
        new(
            new Dictionary<string, Expression<Func<Produto, object>>>
            {
                ["Nome"] = p => p.Nome,
                ["Preco"] = p => p.Preco
            },
            defaultSortBy: "Nome"
        );
}

