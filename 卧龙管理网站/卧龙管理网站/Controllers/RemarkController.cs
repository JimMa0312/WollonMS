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
    public class RemarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Remark
        public ActionResult Index()
        {
            var remarkModels = db.RemarkModels.Include(r => r.Blog);
            return View(remarkModels.ToList());
        }

        // GET: Remark/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remark remarkModel = db.RemarkModels.Find(id);
            if (remarkModel == null)
            {
                return HttpNotFound();
            }
            return View(remarkModel);
        }

        // GET: Remark/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(db.BlogModels, "BlogID", "BlogID");
            return View();
        }

        // POST: Remark/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RemarkID,RemarkCont,UserID,RemarkTime,Floor,ToFloor,isView,BlogID")] Remark remarkModel)
        {
            if (ModelState.IsValid)
            {
                db.RemarkModels.Add(remarkModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogID = new SelectList(db.BlogModels, "BlogID", "BlogID", remarkModel.BlogId);
            return View(remarkModel);
        }

        // GET: Remark/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remark remarkModel = db.RemarkModels.Find(id);
            if (remarkModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogID = new SelectList(db.BlogModels, "BlogID", "BlogID", remarkModel.BlogId);
            return View(remarkModel);
        }

        // POST: Remark/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RemarkID,RemarkCont,UserID,RemarkTime,Floor,ToFloor,isView,BlogID")] Remark remarkModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remarkModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogID = new SelectList(db.BlogModels, "BlogID", "BlogID", remarkModel.BlogId);
            return View(remarkModel);
        }

        // GET: Remark/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remark remarkModel = db.RemarkModels.Find(id);
            if (remarkModel == null)
            {
                return HttpNotFound();
            }
            return View(remarkModel);
        }

        // POST: Remark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Remark remarkModel = db.RemarkModels.Find(id);
            db.RemarkModels.Remove(remarkModel);
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
