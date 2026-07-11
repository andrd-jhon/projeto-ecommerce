using AutoMapper;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    public class ProdutoDTOMappingProfile: Profile
    {
        public ProdutoDTOMappingProfile ()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
