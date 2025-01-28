using CRUD_Practica.Data;
using CRUD_Practica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD_Practica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbcontext _contexto;

        public HomeController(ApplicationDbcontext contexto)
        {
            _contexto = contexto;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.contacto.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                //Agregar fecha y hora actual
                contacto.CreationDate = DateTime.Now;

                _contexto.contacto.Add(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
                //return RedirectToAction(nameof"Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var contacto = _contexto.contacto.Find(id);
            if(id == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
                //return RedirectToAction(nameof"Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _contexto.contacto.Find(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _contexto.contacto.Find(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarContacto(int? id)
        {
            var contacto = await _contexto.contacto.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }
            //Ejecutamos el Delete
            _contexto.contacto.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
