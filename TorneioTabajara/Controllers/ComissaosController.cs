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
    public class ComissaosController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Comissaos
        public ActionResult Index(string nome, Cargo? cargo)
        {
            var comissaos = db.Comissaos.Include(c => c.Time).AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                comissaos = comissaos.Where(c => c.Nome.Contains(nome));
            }

            if (cargo.HasValue)
            {
                comissaos = comissaos.Where(c => c.Cargo == cargo.Value);
            }

            ViewBag.Cargo = Enum.GetValues(typeof(Cargo));

            return View(comissaos.ToList());
        }

        // GET: Comissaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comissao comissao = db.Comissaos.Find(id);
            if (comissao == null)
            {
                return HttpNotFound();
            }
            return View(comissao);
        }

        // GET: Comissaos/Create
        public ActionResult Create()
        {
            ViewBag.TimeId = new SelectList(db.Times, "Id", "Nome");
            return View();
        }

        // POST: Comissaos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeId,Nome,DataNascimento,Cargo")] Comissao comissao)
        {
            if (ModelState.IsValid)
            {
                db.Comissaos.Add(comissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.Times, "Id", "Nome", comissao.TimeId);
            return View(comissao);
        }

        // GET: Comissaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comissao comissao = db.Comissaos.Find(id);
            if (comissao == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimeId = new SelectList(db.Times, "Id", "Nome", comissao.TimeId);
            return View(comissao);
        }

        // POST: Comissaos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeId,Nome,DataNascimento,Cargo")] Comissao comissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TimeId = new SelectList(db.Times, "Id", "Nome", comissao.TimeId);
            return View(comissao);
        }

        // GET: Comissaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comissao comissao = db.Comissaos.Find(id);
            if (comissao == null)
            {
                return HttpNotFound();
            }
            return View(comissao);
        }

        // POST: Comissaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comissao comissao = db.Comissaos.Find(id);
            db.Comissaos.Remove(comissao);
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
