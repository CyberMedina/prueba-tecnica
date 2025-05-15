using prueba_tecnica.Models;

namespace prueba_tecnica.Services
{
    public class CuentaService
    {
        private static readonly List<CuentaBancaria> _cuentas = [];

        private static int _contadorCuentas = 0;


        public CuentaBancaria? CrearCuenta(decimal saldoInicial, out string error)
        {
            if(saldoInicial < 0)
            {
                error = "El saldo inicial no puede ser menor a 0";
                return null;
            }

            var cuenta = new CuentaBancaria
            {
                NumeroCuenta = CrearNumeroCuenta(),
                Saldo = saldoInicial
            };

            _cuentas.Add(cuenta);
            error = string.Empty;
            return cuenta;


        }

        private static string CrearNumeroCuenta()
        {
            _contadorCuentas++;

            var prefijo = "CTH";
            var ano = DateTime.UtcNow.Year;
            var posicion = _contadorCuentas;

            return $"{prefijo} - {ano} - {posicion}";

        }
    }
}
