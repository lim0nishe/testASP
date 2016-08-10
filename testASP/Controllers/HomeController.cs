using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testASP.DAL;
using System.Data.Entity;
using testASP.Models;
using System.Net;

namespace testASP.Controllers
{
    public class HomeController : Controller
    {
        private FilmsContext db = new FilmsContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string genre, string actorName)
        {
            var result = new List<Film>();
            List<Film> tmp;
            // TODO: modify search to complex sql query

            if (name != "")
            {
                // Find by Name
                foreach (var film in db.Films.Where(x => x.Name.Contains(name)))
                {
                    result.Add(film);
                }
            }
            else result = db.Films.ToList();
            if (genre != "")
            {
                // TODO: fix genre search
                // Delete results with another genre
                
                tmp = result.Where(x => !x.Genre.Equals(genre)).ToList();
                foreach (var film in tmp)
                {
                    result.Remove(film);
                }
            }
            if(actorName != "")
            {
                tmp = new List<Film>();

                // Collect films without this actor
                foreach(var film in result)
                {
                    bool flag = false;
                    foreach(var actor in film.Actors)
                    {
                        if (actor.FirstName == actorName)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        tmp.Add(film);
                }

                // Delete them from result
                foreach(var film in tmp)
                {
                    result.Remove(film);
                }
            }

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}