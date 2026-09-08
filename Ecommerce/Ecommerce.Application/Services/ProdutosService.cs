using AutoMapper;
using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.Common.Sorting;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services
{
    public class ProdutosService: IProdutosService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISortingApplier _sortingApplier;

        public ProdutosService(IMapper mapper, IUnitOfWork unitOfWork, ISortingApplier sortingApplier)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sortingApplier = sortingApplier;
        }

        public PagedList<ProdutoDTO> CarregarProdutos(
            PaginationParameters paginationParameters, 
            SortingParameters sortingParameters,
            string? search)
        {
            var query = _unitOfWork.ProdutoRepository.SearchByName(search);

            query = _sortingApplier.Apply(query, sortingParameters, ProdutoSortFields.Definition);

            var pagedList = PagedListFactory.Create(query, paginationParameters, map: p => _mapper.Map<ProdutoDTO>(p));

            return pagedList;
        }

        public ProdutoDTO CreateProduto (ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            produto = _unitOfWork.ProdutoRepository.Create(produto);

            _unitOfWork.Commit();

            produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;
        }

        public ProdutoDTO UpdateProduto (ProdutoDTO produtoDTO, int id)
        {
            if (produtoDTO.Id != id)
                throw new ArgumentException("O ID informado não corresponde ao ID do produto.");

            var produto = _unitOfWork.ProdutoRepository.GetById(id) 
                ?? throw new InvalidOperationException("Produto não encontrado.");

            produto.Atualizar(produtoDTO.Nome, produtoDTO.Preco, produtoDTO.CategoriaId);

            var produtoAtualizado = _unitOfWork.ProdutoRepository.Update(produto);

            _unitOfWork.Commit();

            return _mapper.Map<ProdutoDTO>(produtoAtualizado);
        }

        public ProdutoDTO DeleteProduto(ProdutoDTO produtoDTO)
        {
            if (produtoDTO.Ativo)
                produtoDTO.Ativo = false;

            var produto = _mapper.Map<Produto>(produtoDTO);

            produtoDTO = _mapper.Map<ProdutoDTO>(_unitOfWork.ProdutoRepository.Update(produto));

            _unitOfWork.Commit();

            return produtoDTO;
        }
    }
}
