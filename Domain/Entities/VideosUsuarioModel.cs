using System;

namespace RecomendadosYTAPI.WebAPI.Domain.Entities
{
    public class VideosUsuarioModel
    {
        public DateTime DataOcorrencia { get; set; }
        
        public string Videos { get; set; }

        public string Label { get; set; }
    }
}
