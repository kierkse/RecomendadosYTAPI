using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;
using RecomendadosYTAPI.Application.Repository;

namespace RecomendadosYTAPI.Infra.Repository
{
    public abstract class YoutubeGetRecomendadosRepositoryCrawlerBase : IYoutubeGetRecomendadosRepository
    {
        public async Task<VideosUsuario> GetRecomendados(Usuario usuario)
        {
            var regionDetails = await getRegionDetails(usuario);
            return await getVideosList(regionDetails);
        }

        protected abstract Task<VideosUsuario> getRegionDetails(Usuario usuario);

        protected abstract Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario);
    }
}