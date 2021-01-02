using System;
using System.Threading.Tasks;
using RecomendadosYTAPI.Application.DTO;

namespace RecomendadosYTAPI.Infra.Repository
{
    public class YoutubeBRGetRecomendadosRepository : YoutubeGetRecomendadosRepositoryCrawlerBase
    {
        protected override Task<VideosUsuario> getRegionDetails(Usuario usuario)
        {
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { Label = "Veja uma lista de vídeos que pode te interessar", Videos = usuario.FaixaEtaria } );
        }

        protected override Task<VideosUsuario> getVideosList(VideosUsuario videosUsuario)
        {
            string[] allVideos = {
                "Galinha Pintadinha, Canção da Barata",
                "Animes que serão lançados em 2021, Top 10 músicas do BTS, Deixe-me ir",
                "Compilado de gatos fofinhos #12, Casos de Covid-19 aumentam após eleições, Melhores músicas sertanejo 2020" };

            string returnVideos;
            string returnLabel = videosUsuario.Label;

            switch (videosUsuario.Videos)
            {
                case "crianca":
                    returnVideos = allVideos[0];
                    break;
                case "adolescente":
                    returnVideos = allVideos[1];
                    break;
                case "adulto":
                    returnVideos = allVideos[2];
                    break;
                default:
                    returnLabel = "Faixa etária indisponível";
                    returnVideos = "";
                    break;
            }
            
            return Task.FromResult<VideosUsuario>(new VideosUsuario() { DataOcorrencia = DateTime.UtcNow, Label = returnLabel } );
        }
    }
}