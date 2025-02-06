using ControlCambioApi.Models;
using ControlCambioApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Reflection;

namespace ControlCambioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaController : ControllerBase
    {
        private readonly ITasasServices _tasaService;


        public TasaController(ITasasServices service)
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
        public async Task<IActionResult> UpdateTasas(TasasPDTO pais)
        {
            var result = await _tasaService.UpdateTasas(pais);
            return Ok(result);
        }

     
        [HttpGet("Tasas/{pais}")]
        public async Task<IActionResult> Venezuela(decimal por, string pais) { 
            var Tasas = await _tasaService.GetTasas(por,pais);

            return Ok(Tasas);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasaPreferencial()
        {
            var Tasas = await _tasaService.GetTasaPreferencials();
            return Ok(Tasas);
        }
    }
}
