namespace prueba_tecnica.Models
{
    public class CuentaBancaria
    {
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new ();
    }
}
