﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectC.DataContext;
using ProjectC.Models;

namespace ProjectC.Controllers
{
    public class labelController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: label
        public ActionResult Index()
        {
            return View(db.labels.ToList());
        }

        // GET: label/Details/5

        // GET: label/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            label label = db.labels.Where(x => x.labelid == id).FirstOrDefault();
            db.labels.Remove(label);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: label/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "labelid,labelname")] label labels)
        {
            if (ModelState.IsValid && labels.labelname != null)
            {
                if (db.labels.Any(check => check.labelname == labels.labelname))
                {
                    ViewBag.Message = string.Format("Label Exist");
                    return View();
                }
                db.labels.Add(labels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: label/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            label labels = db.labels.Find(id);
            if (labels == null)
            {
                return HttpNotFound();
            }
            return View(labels);
        }

        // POST: label/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "labelid,labelname")] label labels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labels);
        }

        // GET: label/Delete/5
     
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
