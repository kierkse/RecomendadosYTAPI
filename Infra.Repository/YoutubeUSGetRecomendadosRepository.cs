using System;
using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;

namespace RecomendadosYTAPI.Infra.Repository
{
    public class YoutubeUSGetRecomendadosRepository : YoutubeGetRecomendadosRepositoryCrawlerBase
    {
        protected override Task<VideosUsuario> getRegionDetails(Usuario usuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { Label = "Check out a videos list that could interest you", Videos = usuario.FaixaEtaria } );
        }

        protected override Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario)
        {
            string[] allVideos = {
                "Baby shark doo doo, Fortnite epic gameplay",
                "Miss Kobayachi-san Episode 1, Did Dream cheat on his speedrun? Alan Saturdays",
                "The CRAZIEST records of Guinness Book, [LIVE] Joe Biden assuming presidency of United States 2021" };

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