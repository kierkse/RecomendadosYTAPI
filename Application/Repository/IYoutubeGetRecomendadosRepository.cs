using RecomendadosYTAPI.Application.DTO;
using System.Threading.Tasks;

namespace RecomendadosYTAPI.Application.Repository
{
    public interface IYoutubeGetRecomendadosRepository
    {
        Task<VideosUsuario> GetRecomendados(Usuario usuario);
    }
}
