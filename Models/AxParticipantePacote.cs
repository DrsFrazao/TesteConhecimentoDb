namespace TesteConhecimentoDb.Models;

public class AxParticipantePacote
{
    public int CodPar { get; set; }
    public int CodPacote { get; set; }

    public virtual Participante Participante { get; set; } = null!;
    public virtual Pacote Pacote { get; set; } = null!;
}
