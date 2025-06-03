using System.ComponentModel.DataAnnotations;

namespace TesteConhecimentoDb.Models
{
    /* public class Atividade
     {
         [Key]
         public int CodAtv { get; set; }

         public string DescAtv { get; set; } = string.Empty;
         public int Vagas { get; set; }
         public decimal Preco { get; set; }

         public virtual ICollection<AxParticipanteAtividade> AxParticipanteAtividades { get; set; } = new List<AxParticipanteAtividade>();
     }*/


    using System.ComponentModel.DataAnnotations;

    public class Atividade
    {
        [Key] // <- ESSENCIAL
        public int CodAtv { get; set; }

        public string DescAtv { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int Vagas { get; set; } // <- novo campo

        public virtual ICollection<AxParticipanteAtividade> AxParticipanteAtividades { get; set; } = new List<AxParticipanteAtividade>();
    }








}
