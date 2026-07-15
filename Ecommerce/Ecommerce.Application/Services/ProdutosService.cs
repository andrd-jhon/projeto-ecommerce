using AutoMapper;
using Ecommerce.Application.DTOs.Produto;
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

        public IEnumerable<ProdutoResponseDTO> GetAllProdutos()
        {
            var produtos = _produtoRepository.GetAll();

            var produtosDTOs = new List<ProdutoResponseDTO>();

            foreach (var produto in produtos)
            {
                produtosDTOs.Add(_mapper.Map<ProdutoResponseDTO>(produto));
            } 

            return produtosDTOs;
        }

        public ProdutoDTO CreateProduto (ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            produto = _produtoRepository.Create(produto);

            produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;
        }

        public ProdutoDTO UpdateProduto (ProdutoDTO produtoDTO, int id)
        {
            if (produtoDTO.Id != id)
                throw new ArgumentException("O ID informado não corresponde ao ID do produto.");

            var produto = _produtoRepository.GetById(id) 
                ?? throw new InvalidOperationException("Produto não encontrado.");

            produto.Atualizar(produtoDTO.Nome, produtoDTO.Preco, produtoDTO.CategoriaId);

            var produtoAtualizado = _produtoRepository.Update(produto);

            return _mapper.Map<ProdutoDTO>(produtoAtualizado);
        }

        public ProdutoDTO DeleteProduto (ProdutoDTO produtoDTO)
        {
            if (produtoDTO.Ativo)
                produtoDTO.Ativo = false;

            var produto = _mapper.Map<Produto>(produtoDTO);

            produtoDTO = _mapper.Map<ProdutoDTO>(_produtoRepository.Update(produto));

            return produtoDTO;
        }

        public List<ProdutoDTO> CarregarProdutos ()
        {
            var produtos = _produtoRepository.GetAll();

            var produtosDTOs = new List<ProdutoDTO>();

            foreach (var produto in produtos)
            {
                produtosDTOs.Add(_mapper.Map<ProdutoDTO>(produto));
            }

            return produtosDTOs;
        }
    }
}
