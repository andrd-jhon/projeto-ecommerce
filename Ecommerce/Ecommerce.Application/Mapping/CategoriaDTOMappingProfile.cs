using AutoMapper;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    public class CategoriaDTOMappingProfile: Profile
    {
        public CategoriaDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
