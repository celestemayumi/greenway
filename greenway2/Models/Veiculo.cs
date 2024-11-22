using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace greenway2.Models
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NUMERO_SERIE")]
        public string NumeroSerie { get; set; }

        [Required]
        [StringLength(30)]
        [Column("LATITUDE")]
        public string Latitude { get; set; }

        [Required]
        [StringLength(30)]
        [Column("LONGITUDE")]
        public string Longitude { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression("^[BP]$", ErrorMessage = "O tipo de veículo deve ser 'B' ou 'P'.")]
        [Column("TIPO_VEICULO")]
        public string TipoVeiculo { get; set; }
    }
}

