using AutoMapper;
using RecomendadosYTAPI.Application.DTO;
using RecomendadosYTAPI.WebAPI.Models.Youtube;

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
