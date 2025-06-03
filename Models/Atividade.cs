using System.ComponentModel.DataAnnotations;

namespace TesteConhecimentoDb.Models
{
    public class Atividade
    {
        [Key]
        public int CodAtv { get; set; }

        public string DescAtv { get; set; } = string.Empty;
        public int Vagas { get; set; }
        public decimal Preco { get; set; }

        public virtual ICollection<AxParticipanteAtividade> AxParticipanteAtividades { get; set; } = new List<AxParticipanteAtividade>();
    }
}
