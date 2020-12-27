using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecomendadosYTAPI.Application.DTO;
using RecomendadosYTAPI.Application.Services;
using RecomendadosYTAPI.WebAPI.Models;
using RecomendadosYTAPI.WebAPI.Models.Youtube;

namespace RecomendadosYTAPI.WebAPI.Controllers
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