using Microsoft.EntityFrameworkCore;

namespace TesteConhecimentoDb.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Pacote> Pacotes { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<AxParticipantePacote> AxParticipantePacotes { get; set; }
    public DbSet<AxParticipanteAtividade> AxParticipanteAtividades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pacote>().HasData(
            new Pacote
            {
                CodPacote = 1,
                Descricao = "Gold",
                PrecoAntesVirada = 100.00m,
                PrecoAposVirada = 150.00m,
                DataViradaPreco = new DateTime(2025, 7, 1)
            },
    new Pacote
    {
        CodPacote = 2,
        Descricao = "Platinum",
        PrecoAntesVirada = 150.00m,
        PrecoAposVirada = 200.00m,
        DataViradaPreco = new DateTime(2025, 7, 1)
    });


        modelBuilder.Entity<AxParticipantePacote>().HasKey(x => new { x.CodPar, x.CodPacote });

        modelBuilder.Entity<AxParticipantePacote>()
            .HasOne(x => x.Participante)
            .WithMany(p => p.AxParticipantePacotes)
            .HasForeignKey(x => x.CodPar);

        modelBuilder.Entity<AxParticipantePacote>()
            .HasOne(x => x.Pacote)
            .WithMany(p => p.AxParticipantePacotes)
            .HasForeignKey(x => x.CodPacote);

        modelBuilder.Entity<AxParticipanteAtividade>().HasKey(x => new { x.CodPar, x.CodAtv });

        modelBuilder.Entity<AxParticipanteAtividade>()
            .HasOne(x => x.Participante)
            .WithMany(p => p.AxParticipanteAtividades)
            .HasForeignKey(x => x.CodPar);

        modelBuilder.Entity<AxParticipanteAtividade>()
            .HasOne(x => x.Atividade)
            .WithMany(a => a.AxParticipanteAtividades)
            .HasForeignKey(x => x.CodAtv);
    }
}
