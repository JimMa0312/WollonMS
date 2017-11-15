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
    public class MainKindController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MainKind
        public ActionResult Index()
        {
            return View(db.MainKindModels.ToList());
        }

        // GET: MainKind/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainKind mainKindModel = db.MainKindModels.Find(id);
            if (mainKindModel == null)
            {
                return HttpNotFound();
            }
            return View(mainKindModel);
        }

        // GET: MainKind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainKind/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainKindID,MainKindName")] MainKind mainKindModel)
        {
            if (ModelState.IsValid)
            {
                db.MainKindModels.Add(mainKindModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainKindModel);
        }

        // GET: MainKind/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainKind mainKindModel = db.MainKindModels.Find(id);
            if (mainKindModel == null)
            {
                return HttpNotFound();
            }
            return View(mainKindModel);
        }

        // POST: MainKind/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainKindID,MainKindName")] MainKind mainKindModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainKindModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainKindModel);
        }

        // GET: MainKind/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainKind mainKindModel = db.MainKindModels.Find(id);
            if (mainKindModel == null)
            {
                return HttpNotFound();
            }
            return View(mainKindModel);
        }

        // POST: MainKind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainKind mainKindModel = db.MainKindModels.Find(id);
            db.MainKindModels.Remove(mainKindModel);
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
