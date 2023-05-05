using CakeUpERP.Application.DTO.Usuario;
using CakeUpERP.Domain.Entities;
using AutoMapper;
using CakeUpERP.Application.Enums;

namespace CakeUpERP.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, UsuarioEntity>().ReverseMap();
            CreateMap<CriarUsuarioDTO, UsuarioEntity>()
                .ForMember(dst => dst.Role, src => src.MapFrom(src => (int)RolesUsuarios.Funcionario));

            CreateMap<AtualizarUsuarioDTO, UsuarioEntity>().ReverseMap(); 

        }
    }
}
