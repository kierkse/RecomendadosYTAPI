using System;
using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;

namespace RecomendadosYTAPI.Infra.Repository
{
    public class YoutubeFRGetRecomendadosRepository : YoutubeGetRecomendadosRepositoryCrawlerBase
    {
        protected override Task<VideosUsuario> getRegionDetails(Usuario usuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { Label = "Voir une liste de vidéos qui pourraient vous intéresser", Videos = usuario.FaixaEtaria } );
        }

        protected override Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario)
        {
            string[] allVideos = {
                "Baby shark doo doo, Fortnite epic gameplay",
                "Weird curiousities about Napoleon Bonaparte - History Week, Miss Kobayachi-san Episode 1",
                "When your wife doesn't eat cheese neither wine at breakfast, Worldwide tourists visit Paris to celebrate New Year during Pandemics" };

            string returnVideos;
            string returnLabel = videosUsuario.Label;

            switch (videosUsuario.Videos)
            {
                case "kid":
                    returnVideos = allVideos[0];
                    break;
                case "teen":
                    returnVideos = allVideos[1];
                    break;
                case "adult":
                    returnVideos = allVideos[2];
                    break;
                default:
                    returnLabel = "Undisponible age range";
                    returnVideos = "";
                    break;
            }

            return Task.FromResult<VideosUsuario>(new VideosUsuario() { DataOcorrencia = DateTime.UtcNow, Label = videosUsuario.Label, Videos = returnVideos } );
        }
    }
}