using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorneioTabajara.Data;
using TorneioTabajara.Models;
using System.Data.Entity;

namespace TorneioTabajara.Controllers
{
    public class HomeController : Controller
    {
        private TorneioContext db = new TorneioContext();
        public ActionResult Index()
        {
            return View(); // Views/Home/Index.cshtml
        }

        public ActionResult Tabela()
        {
            return View(); // Views/Home/Tabela.cshtml
        }

        public ActionResult Artilharia()
        {
            return View(); // Views/Home/Artilharia.cshtml
        }
        public ActionResult GerarETrazerPartidas()
        {
            // Chame o método de geração da HomeController aqui
            var times = db.Times.ToList();

            if (times.Count != 20)
            {
                TempData["Erro"] = "É necessário ter exatamente 20 times para gerar a tabela.";
                return RedirectToAction("Index");
            }

            db.Partidas.RemoveRange(db.Partidas.ToList());
            db.SaveChanges();

            var partidas = new List<Partida>();
            int rodada = 1;
            DateTime dataInicial = DateTime.Today.AddDays(1);

            for (int i = 0; i < times.Count - 1; i++)
            {
                for (int j = i + 1; j < times.Count; j++)
                {
                    partidas.Add(new Partida
                    {
                        Time1Id = times[i].Id,
                        Time2Id = times[j].Id,
                        DataHora = dataInicial.AddDays((rodada - 1) * 3),
                        Rodada = rodada++
                    });

                    partidas.Add(new Partida
                    {
                        Time1Id = times[j].Id,
                        Time2Id = times[i].Id,
                        DataHora = dataInicial.AddDays((rodada - 1) * 3),
                        Rodada = rodada++
                    });
                }
            }

            db.Partidas.AddRange(partidas);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
    }