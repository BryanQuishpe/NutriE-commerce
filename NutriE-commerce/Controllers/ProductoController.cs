﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NutriE_commerce.Models;

namespace NutriE_commerce.Controllers
{
    public class ProductoController : Controller
    {
        private nutriecommerceEntities1 db = new nutriecommerceEntities1();

        // GET: Producto
        public ActionResult Index()
        {
            var tblProducto = db.tblProducto.Include(t => t.tblCategoria);
            return View(tblProducto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.catId = new SelectList(db.tblCategoria, "catId", "catNombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proId,catId,proCodigo,proNombre,proStock,proDesc,proPrecio,proObser,proFecha,proEstado")] tblProducto tblProducto)
        {
            if (ModelState.IsValid)
            {
                db.tblProducto.Add(tblProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catId = new SelectList(db.tblCategoria, "catId", "catNombre", tblProducto.catId);
            return View(tblProducto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.catId = new SelectList(db.tblCategoria, "catId", "catNombre", tblProducto.catId);
            return View(tblProducto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proId,catId,proCodigo,proNombre,proStock,proDesc,proPrecio,proObser,proFecha,proEstado")] tblProducto tblProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catId = new SelectList(db.tblCategoria, "catId", "catNombre", tblProducto.catId);
            return View(tblProducto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProducto tblProducto = db.tblProducto.Find(id);
            db.tblProducto.Remove(tblProducto);
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