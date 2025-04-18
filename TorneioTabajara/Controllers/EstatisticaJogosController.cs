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
    public class EstatisticaJogosController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: EstatisticaJogoes
        public ActionResult Index()
        {
            var estatisticasJogos = db.EstatisticasJogos.Include(e => e.Partida);
            return View(estatisticasJogos.ToList());
        }

        // GET: EstatisticaJogoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatisticaJogo estatisticaJogo = db.EstatisticasJogos.Find(id);
            if (estatisticaJogo == null)
            {
                return HttpNotFound();
            }
            return View(estatisticaJogo);
        }

        // GET: EstatisticaJogoes/Create
        public ActionResult Create()
        {
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Id");
            return View();
        }

        // POST: EstatisticaJogoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartidaId,PlacarTime1,PlacarTime2")] EstatisticaJogo estatisticaJogo)
        {
            if (ModelState.IsValid)
            {
                db.EstatisticasJogos.Add(estatisticaJogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Id", estatisticaJogo.PartidaId);
            return View(estatisticaJogo);
        }

        // GET: EstatisticaJogoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatisticaJogo estatisticaJogo = db.EstatisticasJogos.Find(id);
            if (estatisticaJogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Id", estatisticaJogo.PartidaId);
            return View(estatisticaJogo);
        }

        // POST: EstatisticaJogoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartidaId,PlacarTime1,PlacarTime2")] EstatisticaJogo estatisticaJogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estatisticaJogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Id", estatisticaJogo.PartidaId);
            return View(estatisticaJogo);
        }

        // GET: EstatisticaJogoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatisticaJogo estatisticaJogo = db.EstatisticasJogos.Find(id);
            if (estatisticaJogo == null)
            {
                return HttpNotFound();
            }
            return View(estatisticaJogo);
        }

        // POST: EstatisticaJogoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstatisticaJogo estatisticaJogo = db.EstatisticasJogos.Find(id);
            db.EstatisticasJogos.Remove(estatisticaJogo);
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
