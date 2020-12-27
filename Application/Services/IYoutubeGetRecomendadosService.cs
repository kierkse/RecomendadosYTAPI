using System.Collections.Generic;
using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;

namespace RecomendadosYTAPI.Application.Services
{
    public interface IYoutubeGetRecomendadosService
    {
        Task<VideosUsuario> GetRecomendados(Usuario usuario);
    }
}