using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProdutosService: IProdutosService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutosService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProdutoDTO> GetAllProdutos()
        {
            var produtos = _produtoRepository.GetAll();

            var produtosDTOs = new List<ProdutoDTO>();

            foreach (var produto in produtos)
            {
                produtosDTOs.Add(_mapper.Map<ProdutoDTO>(produto));
            } 

            return produtosDTOs;
        }

        public ProdutoDTO CreateProduto (ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            produto = _produtoRepository.Create(produto);

            if (produto == null)
                throw new Exception("Erro ao criar produto");

            produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;
        }

        public ProdutoDTO UpdateProduto (ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            produto = _produtoRepository.Update(produto);

            if (produto == null)
                throw new Exception("Erro ao atualizar produto");

            produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;
        }
    }
}
