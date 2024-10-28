using System.ComponentModel.DataAnnotations;

namespace KamilaReveloExamenProgreso1.Models
{
    public class KRmodelo1
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public bool WithTea { get; set; }
        [Range(0.1, 99.99)]
        public decimal Precio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaRegristo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFinal { get; set; }
    }
}
