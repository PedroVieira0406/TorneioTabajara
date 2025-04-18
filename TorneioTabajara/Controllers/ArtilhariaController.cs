using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TorneioTabajara.Data;
using System.ComponentModel.DataAnnotations.Schema;
using TorneioTabajara.Models;

namespace Liga_Tabajara.Controllers
{
    public class ArtilhariaController : Controller
    {
        private readonly TorneioContext db = new TorneioContext();

        // ViewModel simples para passar os dados à View
        public class ArtilheiroViewModel
        {
            public int JogadorId { get; set; }
            public string Nome { get; set; }
            public int NumeroCamisa { get; set; }
            public string TimeNome { get; set; }
            public int TotalGols { get; set; }
        }

        public class Gol
        {
            public int Id { get; set; }
            [ForeignKey("Jogador")]
            public int JogadorId { get; set; }
            public virtual Jogador Jogador { get; set; }
            [ForeignKey("EstatisticaJogo")]
            public int EstatisticaJogoId { get; set; }
            public virtual EstatisticaJogo EstatisticaJogo { get; set; }
            public int Minuto { get; set; }
            public string TipoGol { get; set; }

            // Adicione esta propriedade para corrigir o erro.
            public int Quantidade { get; set; } // Representa o número de gols marcados.
        }

        // GET: /Artilharia/
        public ActionResult Index()
        {
            var artilheiros = db.Gols
                .Include(g => g.Jogador)
                .Include(g => g.Jogador.Time)
                .GroupBy(g => new
                {
                    g.JogadorId,
                    g.Jogador.Nome,
                    g.Jogador.Camisa,
                    TimeNome = g.Jogador.Time.Nome
                })
                .Select(gr => new ArtilheiroViewModel
                {
                    JogadorId = gr.Key.JogadorId,
                    Nome = gr.Key.Nome,
                    NumeroCamisa = gr.Key.Camisa,
                    TimeNome = gr.Key.TimeNome,
                    TotalGols = gr.Count() // Conta o número de gols 
                })
                .OrderByDescending(a => a.TotalGols)
                .ThenBy(a => a.Nome)
                .ToList();

            return View(artilheiros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}