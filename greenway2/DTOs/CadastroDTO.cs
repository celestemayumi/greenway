namespace greenway2.DTOs
{
    public class CadastroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long NumeroRg  { get; set; }
        public long NumeroCpf { get; set; }
        public string Senha { get; set; }
        public int IdLogin { get; set; }
    }
}
