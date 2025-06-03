using System.ComponentModel.DataAnnotations;

namespace TesteConhecimentoDb.Models
{
    public class Pacote
    {
        [Key]
        public int CodPacote { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public decimal PrecoAntesVirada { get; set; }

        public decimal PrecoAposVirada { get; set; }

        public DateTime DataViradaPreco { get; set; }

        // Preço válido no momento
        public decimal PrecoVigente => DateTime.Now >= DataViradaPreco ? PrecoAposVirada : PrecoAntesVirada;

        public virtual ICollection<AxParticipantePacote> AxParticipantePacotes { get; set; } = new List<AxParticipantePacote>();
    }
}
