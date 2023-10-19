using ADOProject_API.Domain.DTOS;
using ADOProject_API.Domain.Models;
using AutoMapper;

namespace ADOProject_API.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDTO, Produto>();
            CreateMap<CreateProdutoDTO, ReadProdutoDTO>();
            CreateMap<Produto, ReadProdutoDTO>();
            CreateMap<UpdateProdutoDTO, Produto>();
        }
    }
}
