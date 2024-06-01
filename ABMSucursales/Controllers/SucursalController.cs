using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABMSucursales.Models;

namespace ABMSucursales.Controllers
{
    public class SucursalController : Controller
    {
        private readonly AbmsucursalesContext _context;

        public SucursalController(AbmsucursalesContext context)
        {
            _context = context;
        }

        // GET: Sucursal
        public async Task<IActionResult> Index()
        {
            var abmsucursalesContext = _context.Sucursals.Include(s => s.IdResponsableNavigation);
            return View(await abmsucursalesContext.ToListAsync());
        }

        // GET: Sucursal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals
                .Include(s => s.IdResponsableNavigation)
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursal/Create
        public IActionResult Create()
        {
            ViewData["IdResponsable"] = new SelectList(_context.ResponsableSucursals, "IdResponsable", "IdResponsable");
            return View();
        }

        // POST: Sucursal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSucursal,NombreSucursal,DireccionSucursal,TelefonoSucursal,EmailSucursal,AreaSucursal,NumeroEmpleadosSucursal,HorarioAtencionApertura,HorarioAtencionClausura,Observaciones,IdResponsable")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdResponsable"] = new SelectList(_context.ResponsableSucursals, "IdResponsable", "IdResponsable", sucursal.IdResponsable);
            return View(sucursal);
        }

        // GET: Sucursal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            ViewData["IdResponsable"] = new SelectList(_context.ResponsableSucursals, "IdResponsable", "IdResponsable", sucursal.IdResponsable);
            return View(sucursal);
        }

        // POST: Sucursal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSucursal,NombreSucursal,DireccionSucursal,TelefonoSucursal,EmailSucursal,AreaSucursal,NumeroEmpleadosSucursal,HorarioAtencionApertura,HorarioAtencionClausura,Observaciones,IdResponsable")] Sucursal sucursal)
        {
            if (id != sucursal.IdSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.IdSucursal))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdResponsable"] = new SelectList(_context.ResponsableSucursals, "IdResponsable", "IdResponsable", sucursal.IdResponsable);
            return View(sucursal);
        }

        // GET: Sucursal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals
                .Include(s => s.IdResponsableNavigation)
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // POST: Sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sucursals == null)
            {
                return Problem("Entity set 'AbmsucursalesContext.Sucursals'  is null.");
            }
            var sucursal = await _context.Sucursals.FindAsync(id);
            if (sucursal != null)
            {
                _context.Sucursals.Remove(sucursal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
          return (_context.Sucursals?.Any(e => e.IdSucursal == id)).GetValueOrDefault();
        }
    }
}
