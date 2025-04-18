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
    public class PartidasController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Partidas
        public ActionResult Index()
        {
            var partidas = db.Partidas.Include(p => p.EstatisticaJogo).Include(p => p.Time1).Include(p => p.Time2);
            return View(partidas.ToList());
        }

        // GET: Partidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partidas.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // GET: Partidas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId");
            ViewBag.Time1Id = new SelectList(db.Times, "Id", "Nome");
            ViewBag.Time2Id = new SelectList(db.Times, "Id", "Nome");
            return View();
        }

        // POST: Partidas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rodada,Time1Id,Time2Id,DataHora,EstatisticaJogoId")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                db.Partidas.Add(partida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId", partida.Id);
            ViewBag.Time1Id = new SelectList(db.Times, "Id", "Nome", partida.Time1Id);
            ViewBag.Time2Id = new SelectList(db.Times, "Id", "Nome", partida.Time2Id);
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partidas.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId", partida.Id);
            ViewBag.Time1Id = new SelectList(db.Times, "Id", "Nome", partida.Time1Id);
            ViewBag.Time2Id = new SelectList(db.Times, "Id", "Nome", partida.Time2Id);
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rodada,Time1Id,Time2Id,DataHora,EstatisticaJogoId")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.EstatisticasJogos, "PartidaId", "PartidaId", partida.Id);
            ViewBag.Time1Id = new SelectList(db.Times, "Id", "Nome", partida.Time1Id);
            ViewBag.Time2Id = new SelectList(db.Times, "Id", "Nome", partida.Time2Id);
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partidas.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partida partida = db.Partidas.Find(id);
            db.Partidas.Remove(partida);
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
