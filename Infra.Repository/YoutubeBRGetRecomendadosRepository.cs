using System;
using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;

namespace RecomendadosYTAPI.Infra.Repository
{
    public class YoutubeBRGetRecomendadosRepository : YoutubeGetRecomendadosRepositoryCrawlerBase
    {
        protected override Task<VideosUsuario> getRegionDetails(Usuario usuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { Label = "Veja uma lista de vídeos que pode te interessar", } );
        }

        protected override Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { DataOcorrencia = DateTime.UtcNow, Label = videosUsuario.Label } );
        }
    }
}