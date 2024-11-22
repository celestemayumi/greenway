using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace greenway2.Models
{
    public class Login
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required] 
        [MaxLength(50)]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Required] 
        [MaxLength(100)]
        [Column("SENHA")]
        public string Senha { get; set; }
        public Cadastro Cadastro { get; set; }
    }
}
