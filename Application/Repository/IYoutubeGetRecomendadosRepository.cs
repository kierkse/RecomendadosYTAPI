using RecomendadosYoutube.Application.DTO;
using System.Threading.Tasks;

namespace RecomendadosYoutube.Application.Repository
{
    public interface IYoutubeGetRecomendadosRepository
    {
        Task<VideosUsuario> GetRecomendados(Usuario usuario);
    }
}
