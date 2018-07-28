using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tasker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet]
        [Route("[action]/{a}/{b}")]
        public async Task<IActionResult> Suma(int a, int b)
        {
            int resultado = a + b;
            return Ok(resultado);
        }

        [HttpGet]
        [Route("[action]/{a}/{b}")]
        public async Task<IActionResult> Resta(int a, int b)
        {
            int resultado = a - b;
            return Ok(resultado);
        }


        [HttpGet]
        [Route("[action]/{a}/{b}")]
        public async Task<IActionResult> Multiplicacion(int a, int b)
        {
            int resultado = a * b;
            return Ok(resultado);
        }


        [HttpGet]
        [Route("[action]/{a}/{b}")]
        public async Task<IActionResult> Division(int a, int b)
        {
            if (b == 0)
            {
                return BadRequest("El valor B no puede ser Cero");
            }

            double resultado = a / b;
            return Ok(resultado);
        }
    }
}