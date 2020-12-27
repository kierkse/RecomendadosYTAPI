using System;
using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;

namespace RecomendadosYTAPI.Infra.Repository
{
    public class YoutubeUSGetRecomendadosRepository : YoutubeGetRecomendadosRepositoryCrawlerBase
    {
        protected override Task<VideosUsuario> getRegionDetails(Usuario usuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { Label = "Check out a videos list that could interest you", } );
        }

        protected override Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { DataOcorrencia = DateTime.UtcNow, Label = videosUsuario.Label } );
        }
    }
}