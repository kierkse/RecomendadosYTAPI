using AutoMapper;
using RecomendadosYTAPI.Application.DTO;
using RecomendadosYTAPI.WebAPI.Domain.Entities;

namespace RecomendadosYTAPI.WebAPI.Mapper
{
    public class YoutubeMapper : Profile
    {
        public YoutubeMapper()
        {
            CreateMap<UsuarioModel, Usuario>();
            CreateMap<VideosUsuario, VideosUsuarioModel>();
        }
    }
}
