using Microsoft.AspNetCore.Mvc;

using TesteConhecimentoDb.Models;

namespace TesteConhecimentoDb.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext context)
        {
            _context = context;
        }

        // Tela inicial de criação
        public IActionResult Create()
        {
            var viewModel = new ParticipanteInscricaoViewModel
            {
                PacotesDisponiveis = _context.Pacotes.ToList(),
                AtividadesDisponiveis = _context.Atividades.ToList()
            };

            return View(viewModel);
        }

        // POST após preencher o formulário → mostra revisão
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirmacao(ParticipanteInscricaoViewModel viewModel)
        {
            viewModel.PacotesDisponiveis = _context.Pacotes.ToList();
            viewModel.AtividadesDisponiveis = _context.Atividades.ToList();
            return View(viewModel);
        }

        // POST após clicar em "Confirmar e Salvar"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(ParticipanteInscricaoViewModel viewModel)
        {
            var participante = new Participante
            {
                Nome = viewModel.Nome,
                DataNascimento = viewModel.DataNascimento,
                Telefone = viewModel.Telefone,
                AxParticipantePacotes = new List<AxParticipantePacote>
                {
                    new AxParticipantePacote
                    {
                        CodPacote = viewModel.PacoteSelecionadoId
                    }
                },
                AxParticipanteAtividades = viewModel.AtividadesSelecionadasIds
                    .Select(id => new AxParticipanteAtividade { CodAtv = id })
                    .ToList()
            };

            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            // Atualizar o número de vagas das atividades selecionadas
            foreach (var id in viewModel.AtividadesSelecionadasIds)
            {
                var atividade = await _context.Atividades.FindAsync(id);
                if (atividade != null && atividade.Vagas > 0)
                {
                    atividade.Vagas -= 1;
                }
            }

            await _context.SaveChangesAsync(); // Salvar as alterações nas vagas


            return RedirectToAction("Sucesso");
        }

        // Tela de sucesso
        public IActionResult Sucesso()
        {
            return View();
        }
   

    }
}
