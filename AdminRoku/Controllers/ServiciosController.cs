using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminRoku.Models;
using Model;

namespace AdminRoku.Controllers
{
    public class ServiciosController : BaseController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Servicios
        public async Task<ActionResult> Index()
        {
            return View(oServicios.GetServicios(null));
            //return View(Task.Run(()=> { oServicios.GetServicios(null); }));
        }

        // GET: Servicios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = new Servicios();// await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Descripcion,Costo")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                servicios.Estado = true;
                servicios.FechaCreacion = DateTime.Now;
                oServicios.CreateServicios(servicios);
                //await Task.Run(() => { oServicios.CreateServicios(servicios); });
                return RedirectToAction("Index");
            }

            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = new Servicios();// await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion,Costo,Estado,FechaCreacion,FechaModificacion")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                oServicios.EditServicios(servicios);
                //db.Entry(servicios).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = new Servicios();// await db.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Servicios servicios = new Servicios();//await db.Servicios.FindAsync(id);
            //db.Servicios.Remove(servicios);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
               
    }
}
