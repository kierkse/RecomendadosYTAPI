using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;
using RecomendadosYTAPI.Application.Services;
using RecomendadosYTAPI.Application.Repository;

namespace RecomendadosYTAPI.Application.Implementations
{
    public class YoutubeGetRecomendadosServices : IYoutubeGetRecomendadosService
    {
        private readonly IYoutubeGetRecomendadosFactory _Factory;

        public YoutubeGetRecomendadosServices(IYoutubeGetRecomendadosFactory factory)
        {
            _Factory = factory;
        }

        public Task<VideosUsuario> GetRecomendados(Usuario usuario)
        {
            IYoutubeGetRecomendadosRepository repository = _Factory.Create(usuario.country);
            return repository.GetRecomendados(usuario);
        }
    }
}