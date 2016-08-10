using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testASP.DAL;
using testASP.Models;

namespace testASP.Controllers
{
    public class ActorsController : Controller
    {
        private FilmsContext db = new FilmsContext();

        // GET: Actors
        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            var filmList = db.Films.ToList();
            ViewData["filmList"] = filmList;
            return View();
        }

        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,SecondName,Patronymic,Sex,Age,SelectedFilmIds")] Actor actor)
        {
            // Push films list to the view
            var filmList = db.Films.ToList();
            ViewData["filmList"] = filmList;

            if (ModelState.IsValid)
            {
                // Create list of films from selected ids
                if (actor.SelectedFilmIds != null)
                {
                    actor.Films = new List<Film>();
                    foreach (var id in actor.SelectedFilmIds)
                    {
                        actor.Films.Add(filmList.Find(x => x.ID == id));
                    }
                }

                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filmList = db.Films.ToList();
            ViewData["filmList"] = filmList;

            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,SecondName,Patronymic,Sex,Age,SelectedFilmIds")] Actor actor)
        {
            // TODO: Fix non-editable films list

            var filmList = db.Films.ToList();
            ViewData["filmList"] = filmList;
            if (ModelState.IsValid)
            {
                if (actor.SelectedFilmIds != null)
                {
                    actor.Films = new List<Film>();
                    foreach (var id in actor.SelectedFilmIds)
                    {
                        actor.Films.Add(filmList.Find(x => x.ID == id));
                    }
                }

                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
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
