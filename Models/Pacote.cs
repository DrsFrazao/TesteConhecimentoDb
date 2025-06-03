using System.ComponentModel.DataAnnotations;

namespace TesteConhecimentoDb.Models
{
    public class Pacote
    {
        [Key]
        public int CodPacote { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public DateTime DataViradaPreco { get; set; }

        public virtual ICollection<AxParticipantePacote> AxParticipantePacotes { get; set; } = new List<AxParticipantePacote>();
    }
}
