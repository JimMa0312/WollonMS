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
    public class PerKindController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerKind
        public ActionResult Index()
        {
            return View(db.PerKindModels.ToList());
        }

        // GET: PerKind/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerKind perKindModel = db.PerKindModels.Find(id);
            if (perKindModel == null)
            {
                return HttpNotFound();
            }
            return View(perKindModel);
        }

        // GET: PerKind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerKind/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerKindID,PerKindName")] PerKind perKindModel)
        {
            if (ModelState.IsValid)
            {
                db.PerKindModels.Add(perKindModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perKindModel);
        }

        // GET: PerKind/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerKind perKindModel = db.PerKindModels.Find(id);
            if (perKindModel == null)
            {
                return HttpNotFound();
            }
            return View(perKindModel);
        }

        // POST: PerKind/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerKindID,PerKindName")] PerKind perKindModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perKindModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perKindModel);
        }

        // GET: PerKind/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerKind perKindModel = db.PerKindModels.Find(id);
            if (perKindModel == null)
            {
                return HttpNotFound();
            }
            return View(perKindModel);
        }

        // POST: PerKind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerKind perKindModel = db.PerKindModels.Find(id);
            db.PerKindModels.Remove(perKindModel);
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
