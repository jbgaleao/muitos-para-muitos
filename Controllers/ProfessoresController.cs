using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using muitos_para_muitos.Contexto;
using muitos_para_muitos.Models;

namespace muitos_para_muitos.Controllers
{
    public class ProfessoresController : Controller
    {
        private Context db = new Context();


        public ActionResult Index()
        {
            return View(db.PROFESSORES.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.PROFESSORES.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        public ActionResult Create()
        {
            ViewBag.Disciplinas = db.DISCIPLINAS.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessorId,Nome,CargaHoraria")] Professor professor)
        {
            string listDisciplinas = Request.Form["chkDisciplina"];

            if (!string.IsNullOrEmpty(listDisciplinas))
            {
                int[] spltDisc = listDisciplinas.Split(',').Select(Int32.Parse).ToArray();

                if (spltDisc.Count() > 0)
                {
                    List<Disciplina> profDisciplinas = db.DISCIPLINAS
                                             .Where(d => spltDisc
                                             .Contains(d.DisciplinaId)).ToList();

                    professor.Disciplinas.AddRange(profDisciplinas);
                }
            }
            if (ModelState.IsValid)
            {
                db.PROFESSORES.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professor);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.PROFESSORES.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessorId,Nome,CargaHoraria")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professor);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.PROFESSORES.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.PROFESSORES.Find(id);
            db.PROFESSORES.Remove(professor);
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
