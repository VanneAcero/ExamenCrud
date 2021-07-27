using ExamenCrud.Data;
using ExamenCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCrud.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SociosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            List<Socio> socio = new List<Socio>();
                socio = _applicationDbContext.Socio.ToList();
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Socio socio)
        {
            try
            {
                socio.Estado = 1;
                _applicationDbContext.Add(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                
                return View(socio);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Details(string Cedula)
        {

            if (string.IsNullOrEmpty(Cedula))
                return RedirectToAction("Index");
            Socio socio = _applicationDbContext.Socio.Where(v => v.Cedula == Cedula).FirstOrDefault();
            if (socio == null)
                return RedirectToAction("Index");
            return View(socio);
        }
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))

                return RedirectToAction("Index");

            Socio socio = _applicationDbContext.Socio.Where(v => v.Cedula == id).FirstOrDefault();
            if (socio == null)
                return RedirectToAction("Index");
            return View(socio);
        }
        
        [HttpPost]
        public IActionResult Edit(string id, Socio socio)
        {
            if (id != socio.Cedula)
                return RedirectToAction("Index");
            try
            {
                socio.Estado = 1;
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
               
                return View(socio);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Desactivar(string id)
        {
            if (string.IsNullOrEmpty(id))

                return RedirectToAction("Index");


            Socio socio = _applicationDbContext.Socio.Where(v => v.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 0;
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        
        public IActionResult Activar(string id)
        {
            if (string.IsNullOrEmpty(id))

                return RedirectToAction("Index");


            Socio socio = _applicationDbContext.Socio.Where(v => v.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 1;
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
