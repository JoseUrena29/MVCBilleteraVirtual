namespace MVCBilleteraVirtual.Models
{
    public class Tarjetas
    {
        public Int32 IDTarjeta { get; set; }
        public string? Dueño { get; set; }
        public string? Banco { get; set; }
        public string? Emisor { get; set; }
        public string? NumeroTarjeta { get; set; }
        public string? CodigoCVV { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? FotoBanco { get; set; }
        public string? FotoEmisor { get; set; }
    }
}
