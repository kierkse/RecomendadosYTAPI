using System;
using System.Collections.Generic;

namespace RecomendadosYTAPI.WebAPI.Models.Youtube
{
    public class VideosUsuarioModel
    {
        public DateTime DataOcorrencia { get; set; }
        
        public string Videos { get; set; }

        public string Label { get; set; }
    }
}
