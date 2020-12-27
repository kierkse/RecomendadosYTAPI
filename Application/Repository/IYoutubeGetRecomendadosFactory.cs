using System;

namespace RecomendadosYTAPI.Application.Repository
{
    public interface IYoutubeGetRecomendadosFactory
    {
        IYoutubeGetRecomendadosFactory Register(string country, Type repository);
        IYoutubeGetRecomendadosRepository Create(string country);
    }
}
