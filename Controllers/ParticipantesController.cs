using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // GET: Participantes/Create
        public IActionResult Create()
        {
            var viewModel = new ParticipanteInscricaoViewModel
            {
                PacotesDisponiveis = _context.Pacotes.ToList(),
                AtividadesDisponiveis = _context.Atividades.ToList()
            };

            return View(viewModel);
        }

        // POST: Participantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParticipanteInscricaoViewModel viewModel)
        {
            if (ModelState.IsValid)
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
                    AxParticipanteAtividades = viewModel.AtividadesSelecionadasIds.Select(id => new AxParticipanteAtividade
                    {
                        CodAtv = id
                    }).ToList()
                };

                _context.Participantes.Add(participante);
                await _context.SaveChangesAsync();

                return RedirectToAction("Confirmacao", viewModel);
            }

            // Caso o ModelState seja inválido, reenvia os dados pro form
            viewModel.PacotesDisponiveis = _context.Pacotes.ToList();
            viewModel.AtividadesDisponiveis = _context.Atividades.ToList();

            return View(viewModel);
        }

        public IActionResult Confirmacao(ParticipanteInscricaoViewModel dados)
        {
            dados.PacotesDisponiveis = _context.Pacotes.ToList();
            dados.AtividadesDisponiveis = _context.Atividades.ToList();
            return View(dados);
        }


    }
}
