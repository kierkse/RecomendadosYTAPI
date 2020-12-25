using System;
using System.Threading.Tasks;
using RecomendadosYoutube.Application.DTO;

namespace RecomendadosYoutube.Infra.Repository
{
    public class YoutubeFRGetRecomendadosRepository : YoutubeGetRecomendadosRepositoryCrawlerBase
    {
        protected override Task<VideosUsuario> getRegionDetails(Usuario usuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { Label = "Voir une liste de vidéos qui pourraient vous intéresser", } );
        }

        protected override Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { DataOcorrencia = DateTime.UtcNow, Label = videosUsuario.Label } );
        }
    }
}