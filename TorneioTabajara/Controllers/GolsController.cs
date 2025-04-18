using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TorneioTabajara.Data;
using TorneioTabajara.Models;

namespace TorneioTabajara.Controllers
{
    public class GolsController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Gols
        public ActionResult Index()
        {
            var gols = db.Gols.Include(g => g.EstatisticaJogo).Include(g => g.Jogador);
            return View(gols.ToList());
        }

        // GET: Gols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gol gol = db.Gols.Find(id);
            if (gol == null)
            {
                return HttpNotFound();
            }
            return View(gol);
        }

        // GET: Gols/Create
        public ActionResult Create()
        {
            ViewBag.EstatisticaJogoId = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId");
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome");
            return View();
        }

        // POST: Gols/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JogadorId,EstatisticaJogoId,Minuto,TipoGol")] Gol gol)
        {
            if (ModelState.IsValid)
            {
                db.Gols.Add(gol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstatisticaJogoId = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId", gol.EstatisticaJogoId);
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome", gol.JogadorId);
            return View(gol);
        }

        // GET: Gols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gol gol = db.Gols.Find(id);
            if (gol == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstatisticaJogoId = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId", gol.EstatisticaJogoId);
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome", gol.JogadorId);
            return View(gol);
        }

        // POST: Gols/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JogadorId,EstatisticaJogoId,Minuto,TipoGol")] Gol gol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstatisticaJogoId = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId", gol.EstatisticaJogoId);
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome", gol.JogadorId);
            return View(gol);
        }

        // GET: Gols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gol gol = db.Gols.Find(id);
            if (gol == null)
            {
                return HttpNotFound();
            }
            return View(gol);
        }

        // POST: Gols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gol gol = db.Gols.Find(id);
            db.Gols.Remove(gol);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
