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
            Assert.Equal(1000, cuenta.Saldo);
            Assert.Equal(string.Empty, error);
        }
    }
}
