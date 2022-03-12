using AppCDS.Data;
using AppCDS.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppCDS.Controllers
{
    public class InformacionController : Controller
    {
        private readonly DiscosDBContext _context;

        public InformacionController(DiscosDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DiscoCategoriasViewModel discoCategoriasVM)
        {
            //Obtiene lista de autores
            IQueryable<string> AutoresQuery = _context.Disco.OrderBy(p => p.Autor).Select(p => p.Autor);

            //Obtiene Lista De Años
            IQueryable<int> AniosQuery = _context.Disco.OrderBy(p => p.Anio).Select(p => p.Anio);

            //Obtiene la lista de discos
            var Discos = _context.Disco.Select(x => x);

            //Filtramos en caso que se llene el SearchString
            if (!string.IsNullOrEmpty(discoCategoriasVM.SearchString))
            {
                Discos = Discos.Where(x => x.NombreDisco.Contains(discoCategoriasVM.SearchString));
            }

            //Filtra por Autor
            if (!string.IsNullOrEmpty(discoCategoriasVM.DiscoAutor))
            {
                Discos = Discos.Where(x => x.Autor == discoCategoriasVM.DiscoAutor);
            }

            //Filtra por año
            if (!string.IsNullOrEmpty(discoCategoriasVM.DiscoAnio.ToString()) && discoCategoriasVM.DiscoAnio > 0)
            {
                Discos = Discos.Where(x => x.Anio == discoCategoriasVM.DiscoAnio);
            }

            //Agrego el SelectList de DiscoAutor
            discoCategoriasVM.Autores = new SelectList(await AutoresQuery.Distinct().ToListAsync());

            //Agrego el SelectList de Año
            discoCategoriasVM.Anios = new SelectList(await AniosQuery.Distinct().ToListAsync());

            //Agrego el listado de discos
            discoCategoriasVM.Discos = await Discos.ToListAsync();

            discoCategoriasVM.TotalDiscos = discoCategoriasVM.Discos.Count;

            return View(discoCategoriasVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Disco = await _context.Disco.FirstOrDefaultAsync(x => x.Id == id);

            if(Disco == null)
            {
                return NotFound();
            }

            return View(Disco);
        }

        //GET: InformacionController/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: InformacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Autor,NombreDisco,NumeroCanciones,Anio")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disco);
        }

        //GET: InformacionController/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Disco = await _context.Disco.FindAsync(id);

            if (Disco == null)
            {
                return NotFound();
            }

            return View(Disco);
        }

        //POST: InformacionController/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Autor,NombreDisco,NumeroCanciones,Anio")] Disco disco)
        {
            if(id != disco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscoExists(disco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(Details), disco);
        }

        // GET: InformacionController/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Disco = await _context.Disco.FirstOrDefaultAsync(m => m.Id == id);

            if (Disco == null)
            {
                return NotFound();
            }

            return View(Disco);
        }

        // POST: InformacionController/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Disco = await _context.Disco.FindAsync(id);
            _context.Disco.Remove(Disco);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool DiscoExists(int id)
        {
            return _context.Disco.Any(x => x.Id == id);
        }
    }
}
