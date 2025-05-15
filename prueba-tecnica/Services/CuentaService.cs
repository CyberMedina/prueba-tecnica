using prueba_tecnica.Models;

namespace prueba_tecnica.Services
{
    public class CuentaService
    {
        private static readonly List<CuentaBancaria> _cuentas = [];

        private static int _contadorCuentas = 0;


        public CuentaBancaria? CrearCuenta(decimal saldoInicial, out string error)
        {
            if (saldoInicial < 0)
            {
                error = "El saldo inicial no puede ser menor a 0";
                return null;
            }

            var cuenta = new CuentaBancaria
            {
                NumeroCuenta = CrearNumeroCuenta(),
                Saldo = saldoInicial
            };

            cuenta.Transacciones.Add(new Transaccion
            {
                Tipo = "Apertura de cuenta",
                Monto = saldoInicial,
                SaldoDespues = saldoInicial
            });

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

            return $"{prefijo}-{ano}-{posicion}";

        }


        public CuentaBancaria? ObtenerCuenta(string numeroCuenta)
        {
            return _cuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        }


        public decimal ConsultarSaldo(string numeroCuenta, out string error)
        {
            var cuenta = ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
            {
                error = "El numero de cuenta no existe";
                return 0;
            }

            error = string.Empty;
            return cuenta.Saldo;


        }

        public bool Depositar(string numeroCuenta, decimal monto, out string error)
        {
            var cuenta = ObtenerCuenta(numeroCuenta);

            if(cuenta == null)
            {
                error = "Cuenta no encontrada";
                return false;
            }

            if(monto < 0)
            {
                error = "El monto debe de ser mayor a 0";
                return false;
            }

            cuenta.Saldo += monto;

            cuenta.Transacciones.Add(new Transaccion
            {
                Tipo = "Deposito",
                Monto = monto,
                SaldoDespues = cuenta.Saldo,

            });

            error = string.Empty;
            return true;

        }


    }
}
