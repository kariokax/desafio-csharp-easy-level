using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaConexa.Dominio.Models;
using ProvaConexa.Repositorio.Data;

namespace ProvaConexa.Api.Controllers
{
    [Route("api/temperatura")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private ITemperaturaRepositorio _temperaturaRepositorio;

        public TemperaturaController(ITemperaturaRepositorio repositorio)
        {
            _temperaturaRepositorio = repositorio;
        }

        [HttpGet]
        [Route("cidade")]
        public async Task<IActionResult> ObterPorCidade([FromQuery] string cidade)
        {
            try
            {
                return Ok(_temperaturaRepositorio.Temperatura(cidade));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("coordenada")]
        public async Task<IActionResult> ObterPorCoordenada([FromQuery] double latitude, [FromQuery] double longitude)
        {
            try
            {
                return Ok(_temperaturaRepositorio.Temperatura(latitude, longitude));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("historico")]
        public async Task<IActionResult> ObterTemperaturasMes([FromQuery] string cidade, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            try
            {
                if (!String.IsNullOrEmpty(cidade))
                    return Ok(_temperaturaRepositorio.Temperaturas(cidade));

                else
                    return Ok(_temperaturaRepositorio.Temperaturas(latitude, longitude));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
