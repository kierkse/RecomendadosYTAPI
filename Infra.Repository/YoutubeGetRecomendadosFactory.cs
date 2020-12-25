using System;
using System.Collections.Generic;
using RecomendadosYoutube.Application.Repository;

namespace RecomendadosYoutube.Infra.Repository
{
    public class YoutubeGetRecomendadosFactory : IYoutubeGetRecomendadosFactory
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly IDictionary<string, Type> _Repositories = new Dictionary<string, Type>();

        public YoutubeGetRecomendadosFactory(IServiceProvider serviceProvider)
        {
            _ServiceProvider = serviceProvider;
        }

        public IYoutubeGetRecomendadosRepository Create(string country)
        {
            IYoutubeGetRecomendadosRepository result = null;

            if (_Repositories.TryGetValue(country, out Type type))
            {
                result = _ServiceProvider.GetService(type) as IYoutubeGetRecomendadosRepository;
            }

            return result;
        }

        public IYoutubeGetRecomendadosFactory Register(string country, Type repository)
        {
            if (!_Repositories.TryAdd(country, repository))
            {
                _Repositories[country] = repository;
            }

            return this;
        }
    }
}