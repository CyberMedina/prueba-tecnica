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

        // 1. Crear cuenta
        [HttpPost("crearCuenta")]
        public ActionResult CrearCuenta([FromBody] decimal saldoInicial)
        {
            var cuenta = _cuentaService.CrearCuenta(saldoInicial, out string error);
            if (cuenta == null) return BadRequest(error);

            return Ok(cuenta);
        }

        // 2. Consultar saldo
        [HttpGet("consultarSaldo")]
        public ActionResult ConsultarSaldo(string numeroCuenta)
        {
            var saldo = _cuentaService.ConsultarSaldo(numeroCuenta, out string error);
            if (!string.IsNullOrEmpty(error)) return NotFound(error);

            return Ok(saldo);
        }

        // 3.1 Realizar depositos
        [HttpPost("depositar")]
        public ActionResult Depositar(string numeroCuenta, [FromBody] decimal monto)
        {

            var exito = _cuentaService.Depositar(numeroCuenta, monto, out string error);
            if (!exito) return BadRequest(error);

            return Ok("Deposito realizado con éxito!");
        }

        // 3.2. Realizar retiros
        [HttpPost("retirar")]
        public ActionResult Retirar(string numeroCuenta, [FromBody] decimal monto)
        {
            var exito = _cuentaService.Retirar(numeroCuenta, monto, out string error);
            if (!exito) return BadRequest(error);

            return Ok("Retiro realizado con éxito!");
        }
    }
}
