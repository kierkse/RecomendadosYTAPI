using System.Threading.Tasks;
using RecomendadosYoutube.Application.DTO;
using RecomendadosYoutube.Application.Services;
using RecomendadosYoutube.Application.Repository;

namespace RecomendadosYoutube.Application.Implementations
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