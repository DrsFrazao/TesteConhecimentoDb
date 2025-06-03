using System.ComponentModel.DataAnnotations;

namespace TesteConhecimentoDb.Models
{
    public class Participante
    {
        [Key]
        public int CodPar { get; set; }

        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; } = string.Empty;

        public virtual ICollection<AxParticipantePacote> AxParticipantePacotes { get; set; } = new List<AxParticipantePacote>();
        public virtual ICollection<AxParticipanteAtividade> AxParticipanteAtividades { get; set; } = new List<AxParticipanteAtividade>();
    }
}
