using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TorneioTabajara.Data;
using TorneioTabajara.Models;

namespace TorneioTabajara.Controllers
{
    public class ResultadosController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Resultados/Detalhes/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var partida = db.Partidas
                .Include(p => p.Time1)
                .Include(p => p.Time2)
                .Include(p => p.EstatisticaJogo.Gols.Select(g => g.Jogador))
                .FirstOrDefault(p => p.Id == id);

            if (partida == null)
                return HttpNotFound();

            var estatistica = partida.EstatisticaJogo;

            var resultadoViewModel = new ResultadoViewModel
            {
                PartidaId = partida.Id,
                Time1 = partida.Time1.Nome,
                Time2 = partida.Time2.Nome,
                PlacarTime1 = estatistica.PlacarTime1,
                PlacarTime2 = estatistica.PlacarTime2,
                Gols = estatistica.Gols
                    .OrderBy(g => g.Minuto)
                    .Select(g => new GolViewModel
                    {
                        Minuto = g.Minuto,
                        Jogador = g.Jogador.Nome,
                        TipoGol = g.TipoGol,
                        Time = g.Jogador.Time.Nome
                    }).ToList()
            };

            return View(resultadoViewModel);
        }
    }

    // ViewModels para apresentação dos resultados
    public class ResultadoViewModel
    {
        public int PartidaId { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public int PlacarTime1 { get; set; }
        public int PlacarTime2 { get; set; }
        public List<GolViewModel> Gols { get; set; }
    }

    public class GolViewModel
    {
        public int Minuto { get; set; }
        public string Jogador { get; set; }
        public string TipoGol { get; set; }
        public string Time { get; set; }
    }
}
