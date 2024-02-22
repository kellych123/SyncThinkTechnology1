using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SyncThinkTechnology.Models;

namespace SyncThinkTechnology.Controllers
{
    public class OrdersController : Controller
    {
        private SyncThinkDatabaseEntities db = new SyncThinkDatabaseEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.CustomerDetail).Include(o => o.Product).Include(o => o.Stock).Include(o => o.Supplier);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.CustomerDetails, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.Quantity = new SelectList(db.Stocks, "Quantity", "Quantity");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierBusinessName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerId,ProductId,SupplierId,ProductBarcode,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.CustomerDetails, "CustomerId", "CustomerName", order.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", order.ProductId);
            ViewBag.Quantity = new SelectList(db.Stocks, "Quantity", "Quantity", order.Quantity);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierBusinessName", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.CustomerDetails, "CustomerId", "CustomerName", order.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", order.ProductId);
            ViewBag.Quantity = new SelectList(db.Stocks, "Quantity", "Quantity", order.Quantity);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierBusinessName", order.SupplierId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,ProductId,SupplierId,ProductBarcode,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.CustomerDetails, "CustomerId", "CustomerName", order.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", order.ProductId);
            ViewBag.Quantity = new SelectList(db.Stocks, "Quantity", "Quantity", order.Quantity);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierBusinessName", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
