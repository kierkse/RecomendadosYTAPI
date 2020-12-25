using System.Collections.Generic;
using System.Threading.Tasks;
using RecomendadosYoutube.Application.DTO;

namespace RecomendadosYoutube.Application.Services
{
    public interface IYoutubeGetRecomendadosService
    {
        Task<VideosUsuario> GetRecomendados(Usuario usuario);
    }
}