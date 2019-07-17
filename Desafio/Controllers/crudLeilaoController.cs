using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio.Models;

namespace Desafio.Controllers
{
    public class crudLeilaoController : Controller
    {
        private DESAFIOEntities db = new DESAFIOEntities();

        // GET: crudLeilao
        public ActionResult Index()
        {
            return View(db.Tbl_Leilao.ToList());
        }

        // GET: crudLeilao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Leilao tbl_Leilao = db.Tbl_Leilao.Find(id);
            if (tbl_Leilao == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Leilao);
        }

        // GET: crudLeilao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: crudLeilao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLeilao,DataAbertura,DataFechamento,NomeProduto,DescricaoProduto,ValorInicial,ValorVendido,Usado")] Tbl_Leilao tbl_Leilao)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Leilao.Add(tbl_Leilao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Leilao);
        }

        // GET: crudLeilao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Leilao tbl_Leilao = db.Tbl_Leilao.Find(id);
            if (tbl_Leilao == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Leilao);
        }

        // POST: crudLeilao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLeilao,DataAbertura,DataFechamento,NomeProduto,DescricaoProduto,ValorInicial,ValorVendido,Usado")] Tbl_Leilao tbl_Leilao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Leilao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Leilao);
        }

        // GET: crudLeilao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Leilao tbl_Leilao = db.Tbl_Leilao.Find(id);
            if (tbl_Leilao == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Leilao);
        }

        // POST: crudLeilao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Leilao tbl_Leilao = db.Tbl_Leilao.Find(id);
            db.Tbl_Leilao.Remove(tbl_Leilao);
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
