using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace greenway2.Models
{
    [Table("GS_HISTORICO")]
    public class Historico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("DATA_USO")]
        public DateTime DataUso { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("LOCAL_PARTIDA")]
        public string LocalPartida { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("LOCAL_DESTINO")]
        public string LocalDestino { get; set; }

        [Required]
        [Column("TEMPO_VIAGEM")]
        public double TempoViagem { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("PERCURSO")]
        public string Percurso { get; set; }

        [Required]
        [ForeignKey("Cadastro")]
        [Column("ID_CADASTRO")]
        public int IdCadastro { get; set; }

        public Cadastro Cadastro { get; set; }

        [Required]
        [ForeignKey("Veiculo")]
        [Column("ID_VEICULO")]
        public int IdVeiculo { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
