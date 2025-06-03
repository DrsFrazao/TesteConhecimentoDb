namespace TesteConhecimentoDb.Models;

public class AxParticipanteAtividade
{
    public int CodPar { get; set; }
    public int CodAtv { get; set; }

    public virtual Participante Participante { get; set; } = null!;
    public virtual Atividade Atividade { get; set; } = null!;
}
