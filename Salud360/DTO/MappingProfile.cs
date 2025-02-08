using AutoMapper;
using Salud360.Models;
using Salud360.DTO;
using Salud360.DTO.EjercicioDTO;
using Salud360.DTO.FavoritoDTO;
using Salud360.DTO.PlanNutricionalDTO;
using Salud360.DTO.ProductoAlimenticioDTO;
using Salud360.DTO.ProgresoUsuarioDTO;
using Salud360.DTO.UsuarioDTO;
using Salud360.DTO.VerificacionUsuarioDTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ejercicio, EjercicioGetDTO>().ReverseMap();
        CreateMap<EjercicioInsertDTO, Ejercicio>().ReverseMap();
        CreateMap<EjercicioPutDTO, Ejercicio>().ReverseMap();

        CreateMap<Favorito, FavoritoGetDTO>().ReverseMap();
        CreateMap<FavoritoInsertDTO, Favorito>().ReverseMap();
        CreateMap<FavoritoPutDTO, Favorito>().ReverseMap();

        CreateMap<PlanNutricional, PlanNutricionalGetDTO>().ReverseMap();
        CreateMap<PlanNutricionalInsertDTO, PlanNutricional>().ReverseMap();
        CreateMap<PlanNutricionalPutDTO, PlanNutricional>().ReverseMap();

        CreateMap<ProductoAlimenticio, ProductoAlimenticioGetDTO>().ReverseMap();
        CreateMap<ProductoAlimenticioInsertDTO, ProductoAlimenticio>().ReverseMap();
        CreateMap<ProductoAlimenticioPutDTO, ProductoAlimenticio>().ReverseMap();

        CreateMap<ProgresoUsuario, ProgresoUsuarioGetDTO>().ReverseMap();
        CreateMap<ProgresoUsuarioInsertDTO, ProgresoUsuario>().ReverseMap();
        CreateMap<ProgresoUsuarioPutDTO, ProgresoUsuario>().ReverseMap();

        CreateMap<Usuario, UsuarioGetDTO>().ReverseMap();
        CreateMap<UsuarioInsertDTO, Usuario>().ReverseMap();
        CreateMap<UsuarioPutDTO, Usuario>().ReverseMap();

        CreateMap<VerificacionUsuario, VerificacionUsuarioGetDTO>().ReverseMap();
        CreateMap<VerificacionUsuarioInsertDTO, VerificacionUsuario>().ReverseMap();
        CreateMap<VerificacionUsuarioPutDTO, VerificacionUsuario>().ReverseMap();
    }
}
