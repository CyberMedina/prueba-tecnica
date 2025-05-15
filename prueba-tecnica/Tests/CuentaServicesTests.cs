using prueba_tecnica.Models;
using prueba_tecnica.Services;
using Xunit;


namespace prueba_tecnica.Tests
{
    public class CuentaServicesTests
    {
        private readonly CuentaService _service = new();

        [Fact]
        public void CrearCuenta_ConSaldoInicial_DeberiCrearCuentaCorrectamente()
        {
            var cuenta = _service.CrearCuenta(1000, out string error);

            Assert.NotNull(cuenta);
            Assert.Equal(1000, cuenta!.Saldo);
            Assert.Equal(string.Empty, error);
        }

        [Fact]
        public void Depositar_EnCuentaExistente_DeberiaIncrementarSaldo()
        {
            var cuenta = _service.CrearCuenta(500, out _);
            Assert.NotNull(cuenta); 
            var resultado = _service.Depositar(cuenta!.NumeroCuenta, 300, out string error);

            Assert.True(resultado);
            Assert.Equal(800, cuenta.Saldo);
            Assert.Equal(string.Empty, error);
        }
    }
}
