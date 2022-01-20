using AspCrud.Requests;
using AutoMapper;
using BLL.Entities;

namespace AspCrud.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Crypto, CryptoViewModel>();
        }
    }
}
