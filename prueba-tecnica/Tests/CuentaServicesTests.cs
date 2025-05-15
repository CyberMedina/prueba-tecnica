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

        [Fact]
        public void Retirar_ConFondosSuficientes_DeberiaDisminuirSaldo()
        {
            var cuenta = _service.CrearCuenta(1000, out _);
            var resultado = _service.Retirar(cuenta!.NumeroCuenta, 200, out string error);

            Assert.True(resultado);
            Assert.Equal(800, cuenta.Saldo);
            Assert.Equal(string.Empty, error);
        }

        [Fact]
        public void Retirar_SinFondosSuficientes_DeberiaFallar()
        {
            var cuenta = _service.CrearCuenta(100, out _);
            var resultado = _service.Retirar(cuenta!.NumeroCuenta, 200, out string error);

            Assert.False(resultado);
            Assert.Equal("No tiene el saldo disponible para poder realizar este retiro", error);
            Assert.Equal(100, cuenta.Saldo);
        }

       
    }
}
