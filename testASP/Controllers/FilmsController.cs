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
    public class FilmsController : Controller
    {
        private FilmsContext db = new FilmsContext();

        // GET: Films
        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }

        // GET: Films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            var actorList = db.Actors.ToList();
            ViewData["actorList"] = actorList;
            return View();
        }

        // POST: Films/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Genre,Budget,SelectedActorIds")] Film film)
        {
            // Push actors list to the view
            var actorList = db.Actors.ToList();
            ViewData["actorList"] = actorList;

            if (ModelState.IsValid)
            {
                if (film.SelectedActorIds != null)
                {
                    // Create list of actors from selected ids
                    film.Actors = new List<Actor>();
                    foreach (var id in film.SelectedActorIds)
                    {
                        film.Actors.Add(actorList.Find(x => x.ID == id));
                    }
                }

                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var actorList = db.Actors.ToList();
            ViewData["actorList"] = actorList;

            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Genre,Budget,SelectedActorIds")] Film film)
        {
            // TODO: fix non-editable actors list

            var actorList = db.Actors.ToList();
            ViewData["actorList"] = actorList;
            if (ModelState.IsValid)
            {
                if (film.SelectedActorIds != null)
                {
                    film.Actors = new List<Actor>();
                    foreach (var id in film.SelectedActorIds)
                    {
                        film.Actors.Add(actorList.Find(x => x.ID == id));
                    }
                }

                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
