using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.Services;
using prueba_tecnica.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace prueba_tecnica.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class CuentaController: ControllerBase
    {
        private readonly CuentaService _cuentaService = new();

        [HttpPost("crearCuenta")]
        public ActionResult CrearCuenta([FromBody] decimal saldoInicial)
        {
            var cuenta = _cuentaService.CrearCuenta(saldoInicial, out string error);
            if (cuenta == null) return BadRequest(error);

            return Ok(cuenta);
        }
    }
}
