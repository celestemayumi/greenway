namespace greenway2.DTOs
{
    public class HistoricoDTO
    {
        public int Id { get; set; }
        public DateTime DataUso { get; set; }
        public string LocalPartida { get; set; }
        public string LocalDestino { get; set; }
        public double TempoViagem { get; set; }
        public string Percurso { get; set; }
        public int IdCadastro { get; set; }
        public int IdVeiculo { get; set; }
    }
}
