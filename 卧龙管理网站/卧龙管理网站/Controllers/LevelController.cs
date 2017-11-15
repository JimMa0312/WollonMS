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
    public class LevelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Level
        public ActionResult Index()
        {
            return View(db.LevelModels.ToList());
        }

        // GET: Level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level levelModel = db.LevelModels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // GET: Level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Level/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevelID,LevelName")] Level levelModel)
        {
            if (ModelState.IsValid)
            {
                db.LevelModels.Add(levelModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelModel);
        }

        // GET: Level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level levelModel = db.LevelModels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // POST: Level/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevelID,LevelName")] Level levelModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelModel);
        }

        // GET: Level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Level levelModel = db.LevelModels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // POST: Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Level levelModel = db.LevelModels.Find(id);
            db.LevelModels.Remove(levelModel);
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
