using AutoMapper;
using RecomendadosYoutube.Application.DTO;
using RecomendadosYoutube.WebAPI.Models.Youtube;

namespace RecomendadosYoutube.WebAPI.Mapper
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
