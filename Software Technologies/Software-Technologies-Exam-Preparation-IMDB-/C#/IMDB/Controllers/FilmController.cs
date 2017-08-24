using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;
using System.Data.Entity;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new IMDBDbContext())
            {
                var films = db.Films.ToList();
                return View(films);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create() => View();

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (film.HasNullData())
                return RedirectToAction("Create");

            using (var db = new IMDBDbContext())
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                if(id==null||!db.Films.Any(f=>f.Id==id))
                    return RedirectToAction("Index");

                var film = db.Films.Where(f => f.Id == id).First();

                return View(film);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (filmModel.HasNullData())
                return RedirectToAction("Edit");

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Where(f => f.Id == id).First();
                film.MergeFilms(filmModel);
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                if (id == null || !db.Films.Any(f => f.Id == id))
                    return RedirectToAction("Index");

                var film = db.Films.Where(f => f.Id == id).First();

                return View(film);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Where(f => f.Id == id).First();
                db.Films.Remove(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}