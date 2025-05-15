namespace prueba_tecnica.Models
{
    public class Transaccion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Tipo { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public decimal SaldoDespues { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
