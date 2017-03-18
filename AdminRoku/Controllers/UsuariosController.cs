﻿using System;
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
    public class UsuariosController : BaseController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            return View(oUsuarios.GetUsuarios(null));
            // return View(new List<Model.Usuarios>());
        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = new Usuarios();//await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre,Usuario,Contrasena")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                oUsuarios.CreateUsuarios(usuarios);
                //db.Usuarios.Add(usuarios);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = new Usuarios();//await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Usuario,Contrasena,Estado,FechaCreacion,FechaModificacion")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(usuarios).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = new Usuarios();//await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuarios usuarios = new Usuarios();//await db.Usuarios.FindAsync(id);
            //db.Usuarios.Remove(usuarios);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
