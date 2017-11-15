using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WollonMe.Models;
using 卧龙管理网站.Models;

namespace WollonMe.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blogModels = db.BlogModels.Include(b => b.BlogImg).Include(b => b.Level).Include(b => b.MainKind);
            return View(blogModels.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blogModel = db.BlogModels.Find(id);
            if (blogModel == null)
            {
                return HttpNotFound();
            }
            return View(blogModel);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.FileID = new SelectList(db.FileModels, "FileID", "FileName");
            ViewBag.LevelID = new SelectList(db.LevelModels, "LevelID", "LevelName");
            ViewBag.MainKindID = new SelectList(db.MainKindModels, "MainKindID", "MainKindName");
            return View();
        }

        // POST: Blog/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogID,AuthorID,BlogTitle,BlogAbst,BlogCont,BlogSource,UpTime,Tags,PerKinds,isView,ClickNum,RemarkNum,MainKindID,FileID,LevelID")] Blog blogModel)
        {
            if (ModelState.IsValid)
            {
                db.BlogModels.Add(blogModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FileID = new SelectList(db.FileModels, "FileID", "FileName", blogModel.FileId);
            ViewBag.LevelID = new SelectList(db.LevelModels, "LevelID", "LevelName", blogModel.LevelId);
            ViewBag.MainKindID = new SelectList(db.MainKindModels, "MainKindID", "MainKindName", blogModel.MainKindId);
            return View(blogModel);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blogModel = db.BlogModels.Find(id);
            if (blogModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FileID = new SelectList(db.FileModels, "FileID", "FileName", blogModel.FileId);
            ViewBag.LevelID = new SelectList(db.LevelModels, "LevelID", "LevelName", blogModel.LevelId);
            ViewBag.MainKindID = new SelectList(db.MainKindModels, "MainKindID", "MainKindName", blogModel.MainKindId);
            return View(blogModel);
        }

        // POST: Blog/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogID,AuthorID,BlogTitle,BlogAbst,BlogCont,BlogSource,UpTime,Tags,PerKinds,isView,ClickNum,RemarkNum,MainKindID,FileID,LevelID")] Blog blogModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FileID = new SelectList(db.FileModels, "FileID", "FileName", blogModel.FileId);
            ViewBag.LevelID = new SelectList(db.LevelModels, "LevelID", "LevelName", blogModel.LevelId);
            ViewBag.MainKindID = new SelectList(db.MainKindModels, "MainKindID", "MainKindName", blogModel.MainKindId);
            return View(blogModel);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blogModel = db.BlogModels.Find(id);
            if (blogModel == null)
            {
                return HttpNotFound();
            }
            return View(blogModel);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blogModel = db.BlogModels.Find(id);
            db.BlogModels.Remove(blogModel);
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
