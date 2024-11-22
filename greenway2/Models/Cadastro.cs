using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace greenway2.Models
{
    public class Cadastro
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required] 
        [MaxLength(100)]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Required]
        [Column("NUMERO_RG")]
        public long NumeroRg { get; set; }

        [Required]
        [Column("NUMERO_CPF")]
        public long NumeroCpf { get; set; }

        [Required] 
        [MaxLength(100)]
        [Column("SENHA")]
        public string Senha { get; set; }

        [ForeignKey("Login")]
        [Column("ID_LOGIN")]
        public int IdLogin { get; set; }

        public Login Login { get; set; }
    }
}
