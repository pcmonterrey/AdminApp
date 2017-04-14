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
    public class UsuariosServiciosController : BaseController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UsuariosServicios
        public async Task<ActionResult> Index()
        {
            return View(oUsuariosServicios.GetUsuariosServicios(null));
        }

        // GET: UsuariosServicios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosServicios usuariosServicios = new UsuariosServicios();//await db.UsuariosServicios.FindAsync(id);
            if (usuariosServicios == null)
            {
                return HttpNotFound();
            }
            return View(usuariosServicios);
        }

        // GET: UsuariosServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosServicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdServicio,IdUsario,Estado,FechaCreacion,FechaModificacion,FechaInicioServicio,FechaFinServicio,NumeroCreditos")] UsuariosServicios usuariosServicios)
        {
            if (ModelState.IsValid)
            {
                oUsuariosServicios.CreateUsuariosServicios(usuariosServicios);
                //db.UsuariosServicios.Add(usuariosServicios);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuariosServicios);
        }

        // GET: UsuariosServicios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosServicios usuariosServicios = new UsuariosServicios();//await db.UsuariosServicios.FindAsync(id);
            if (usuariosServicios == null)
            {
                return HttpNotFound();
            }
            return View(usuariosServicios);
        }

        // POST: UsuariosServicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdServicio,IdUsario,Estado,FechaCreacion,FechaModificacion,FechaInicioServicio,FechaFinServicio,NumeroCreditos")] UsuariosServicios usuariosServicios)
        {
            if (ModelState.IsValid)
            {
                //oUsuariosServicios.EditUsuariosServicios(usuariosServicios);
                //db.Entry(usuariosServicios).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuariosServicios);
        }

        // GET: UsuariosServicios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosServicios usuariosServicios = new UsuariosServicios();// await db.UsuariosServicios.FindAsync(id);
            if (usuariosServicios == null)
            {
                return HttpNotFound();
            }
            return View(usuariosServicios);
        }

        // POST: UsuariosServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UsuariosServicios usuariosServicios = new UsuariosServicios();//await db.UsuariosServicios.FindAsync(id);
            //db.UsuariosServicios.Remove(usuariosServicios);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
