using ControlCambioApi.Models;
using ControlCambioApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ControlCambioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaController : ControllerBase
    {
        private readonly ITasasServices _tasaService;
        

        public TasaController(ITasasServices service )
        {
            _tasaService = service;          
        }

        [Route("Paises")]
        [HttpGet]
        public async Task<IActionResult> ListaPaises()
        {
            var listaPaises = await _tasaService.GetPais();
            return Ok(listaPaises);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTasas(Pais pais)
        {
            var result = await _tasaService.UpdateTasas( pais);
            return Ok(result);
        }

        [Route("Venezuela")]
        [HttpGet]
        public async Task<IActionResult> Venezuela()
        {
            var Tasas = await _tasaService.GetTasasVenezuela();
            return Ok(Tasas);
        }
        
        [Route("Colombia")]
        [HttpGet]
        public async Task<IActionResult> Colombia()
        {
            var Tasas = await _tasaService.GetTasasColombia();
            return Ok(Tasas);
        }
        [Route("Chile")]
        [HttpGet]
        public async Task<IActionResult> Chile()
        {
            var Tasas = await _tasaService.GetTasasChile();
            return Ok(Tasas);
        }
        [Route("Peru")]
        [HttpGet]
        public async Task<IActionResult> Peru()
        {
            var Tasas = await _tasaService.GetTasasPeru();
            return Ok(Tasas);
        }
        [Route("Ecuador")]
        [HttpGet]
        public async Task<IActionResult>  Ecuador()
        {
            var Tasas = await _tasaService.GetTasasEcuador();
            return Ok(Tasas);
        }
        [Route("Mexico")]
        [HttpGet]
        public async Task<IActionResult> Mexico()
        {
            var Tasas = await _tasaService.GetTasasMexico();
            return Ok(Tasas);
        }
        [Route("Panama")]
        [HttpGet]
        public async Task<IActionResult> Panama()
        {
            var Tasas = await _tasaService.GetTasasPanama();
            return Ok(Tasas);
        }
        [Route("EEUU")]
        [HttpGet]
        public async Task<IActionResult> EEUU()
        {
            var Tasas = await _tasaService.GetTasasEEUU();
            return Ok(Tasas);
        }
        [Route("España")]
        [HttpGet]
        public async Task<IActionResult> España()
        {
            var Tasas = await _tasaService.GetTasasEspaña();
            return Ok(Tasas);
        }
        [Route("Argentina")]
        [HttpGet]
        public async Task<IActionResult> Argentina()
        {
            var Tasas = await _tasaService.GetTasasArgentina();
            return Ok(Tasas);
        }

        [Route("Brasil")]
        [HttpGet]
        public async Task<IActionResult> Brasil()
        {
            var Tasas = await _tasaService.GetTasasBrasil();
            return Ok(Tasas);
        }
    }
}
