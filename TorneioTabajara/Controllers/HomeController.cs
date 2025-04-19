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
            var times = db.Times.Include(t => t.Jogadores).Include(t => t.Comissaos).ToList();

            bool ligaApta = VerificarLigaApta(times);

            ViewBag.LigaApta = ligaApta;
            return View(times);
        }

        private bool VerificarLigaApta(List<Time> times)
        {
            if (times.Count != 20)
                return false;

            foreach (var time in times)
            {
                if (time.Jogadores == null || time.Jogadores.Count < 30)
                    return false;

                if (time.Comissaos == null || time.Comissaos.Count < 5)
                    return false;

                var cargosDistintos = time.Comissaos.Select(c => c.Cargo).Distinct().Count();
                if (cargosDistintos < 5)
                    return false;
            }

            return true;
        }


        public ActionResult PopularBancoDeDados()
        {
            db.Jogadores.RemoveRange(db.Jogadores);
            db.Comissaos.RemoveRange(db.Comissaos);
            db.Times.RemoveRange(db.Times);
            db.SaveChanges();

            Random random = new Random();

            var nomesTimes = new List<string>
            {
                "Tabajara FC", "Galácticos", "Fúria Azul", "Trovões", "Leões do Norte",
                "Águias da Montanha", "Falcões Vermelhos", "Tigres do Cerrado", "Lobos da Serra", "Guerreiros Urbanos",
                "Dragões Dourados", "Fênix Negra", "Cavaleiros do Vale", "Santos de Aço", "Vikings Tropicais",
                "Piratas do Sul", "Espartanos", "Corvos Brancos", "Samurais do Sertão", "Gladiadores Modernos"
            };

            var posicoes = Enum.GetValues(typeof(Posicao)).Cast<Posicao>().ToList();
            var pes = Enum.GetValues(typeof(PePreferido)).Cast<PePreferido>().ToList();
            var cargos = Enum.GetValues(typeof(Cargo)).Cast<Cargo>().ToList();

            foreach (var nomeTime in nomesTimes)
            {
                var time = new Time
                {
                    Nome = nomeTime,
                    Cidade = "Cidade " + random.Next(1, 100),
                    Estado = "Estado " + random.Next(1, 27),
                    AnoFundacao = random.Next(1900, 2022),
                    Estadio = "Estádio " + nomeTime,
                    CapacidadeEstadio = random.Next(10000, 80000),
                    CorPrimaria = "Cor" + random.Next(1, 10),
                    CorSecundaria = "Cor" + random.Next(10, 20),
                    Status = true
                };

                db.Times.Add(time);
                db.SaveChanges(); // salvar aqui pra pegar o ID do time

                // Jogadores
                for (int i = 1; i <= 20; i++)
                {
                    var jogador = new Jogador
                    {
                        Nome = $"Jogador_{nomeTime}_{i}",
                        DataNascimento = DateTime.Now.AddYears(-random.Next(18, 35)),
                        Nacionalidade = "Brasileiro",
                        Posicao = posicoes[random.Next(posicoes.Count)],
                        Camisa = i,
                        Altura = (float)(1.60 + random.NextDouble() * 0.4),
                        Peso = (float)(60 + random.NextDouble() * 30),
                        PePreferido = pes[random.Next(pes.Count)],
                        TimeId = time.Id
                    };

                    db.Jogadores.Add(jogador);
                }

                // Comissão Técnica
                foreach (var cargo in cargos)
                {
                    var membro = new Comissao
                    {
                        Nome = $"Comissao_{nomeTime}_{cargo}",
                        Cargo = cargo,
                        DataNascimento = DateTime.Now.AddYears(-random.Next(30, 60)),
                        TimeId = time.Id
                    };

                    db.Comissaos.Add(membro);
                }

                db.SaveChanges();
            }

            return Content("Banco de dados populado com sucesso!");
        }
    }
}