using blog_cs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace blog_cs.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // GET: Article/List
        public ActionResult List()
        {
            using (var db = new BlogDbContext())
            {
                //Get articles from database
                var articles = db.Articles.Include(a => a.Author).ToList();   // Include() - includes data for the author

                return View(articles);
            }
        }

        //
        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles.Where(a => a.Id == id).Include(a => a.Author).First();
                if (article == null)
                    return HttpNotFound();
                return View(article);
            }
        }

        //
        // GET: Articel/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if(ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    //Finding authorId - searches for the id in the database which matches the current logged in user
                    var authorId = db.Users.Where(u => u.UserName == this.User.Identity.Name).First().Id;

                    article.AuthorId = authorId;
                    article.CreationDate = DateTime.Now;

                    db.Articles.Add(article);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(article);
        }

        //
        // GET: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles.Where(a=>a.Id == id ).Include(a=>a.Author).First();

                if (article == null)
                    return HttpNotFound();

                return View(article);
            }
        }

        //
        // POST: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles.Where(a => a.Id == id).Include(a => a.Author).First();

                if (!IsUserAuthorizedToEdit(article))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                if (article == null)
                    return HttpNotFound();

                db.Articles.Remove(article);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }

        //
        // GET: Article/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new BlogDbContext())
            {
                var article = db.Articles.Where(a => a.Id == id).Include(a => a.Author).First();

                if (!IsUserAuthorizedToEdit(article))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

                if (article == null)
                    return HttpNotFound();

                var model = new ArticleViewModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content
                };

                return View(model);
            }
        }

        //
        // POST: Article/Edit
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var article = db.Articles.FirstOrDefault(a => a.Id == model.Id);

                    article.Title = model.Title;
                    article.Content = model.Content;

                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        private bool IsUserAuthorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }
    }
}