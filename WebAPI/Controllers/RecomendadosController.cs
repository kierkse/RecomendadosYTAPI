using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecomendadosYoutube.Application.DTO;
using RecomendadosYoutube.Application.Services;
using RecomendadosYoutube.WebAPI.Models;
using RecomendadosYoutube.WebAPI.Models.Youtube;

namespace RecomendadosYoutube.WebAPI.Controllers
{
    [Route("api/Youtube/[controller]")]
    [ApiController]
    public class RecomendadosController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IYoutubeGetRecomendadosService _YoutubeGetRecomendadosServices;

        public RecomendadosController(IMapper mapper, IYoutubeGetRecomendadosService youtubeGetRecomendadosServices)
        {
            _Mapper = mapper;
            _YoutubeGetRecomendadosServices = youtubeGetRecomendadosServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<VideosUsuarioModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]UsuarioModel model)
        {
            var debitos = await _YoutubeGetRecomendadosServices.GetRecomendados(_Mapper.Map<Usuario>(model));

            var result = new SuccessResultModel<VideosUsuarioModel>(_Mapper.Map<VideosUsuarioModel>(debitos));

            return Ok(result);
        }
    }
}