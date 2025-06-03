using System.ComponentModel.DataAnnotations;

namespace TesteConhecimentoDb.Models
{
    public class ParticipanteInscricaoViewModel
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public int PacoteSelecionadoId { get; set; }

        public List<int> AtividadesSelecionadasIds { get; set; } = new List<int>();

        // Para popular o formulário
        public List<Pacote> PacotesDisponiveis { get; set; } = new();
        public List<Atividade> AtividadesDisponiveis { get; set; } = new();
    }
}
