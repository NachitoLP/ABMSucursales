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
    public class ResponsableSucursalController : Controller
    {
        private readonly AbmsucursalesContext _context;

        public ResponsableSucursalController(AbmsucursalesContext context)
        {
            _context = context;
        }

        // GET: ResponsableSucursal
        public async Task<IActionResult> Index()
        {
              return _context.ResponsableSucursals != null ? 
                          View(await _context.ResponsableSucursals.ToListAsync()) :
                          Problem("Entity set 'AbmsucursalesContext.ResponsableSucursals'  is null.");
        }

        // GET: ResponsableSucursal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResponsableSucursals == null)
            {
                return NotFound();
            }

            var responsableSucursal = await _context.ResponsableSucursals
                .FirstOrDefaultAsync(m => m.IdResponsable == id);
            if (responsableSucursal == null)
            {
                return NotFound();
            }

            return View(responsableSucursal);
        }

        // GET: ResponsableSucursal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsableSucursal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResponsable,NombreResponsable,ApellidoResponsable,CargoResponsable,EmailResponsable,TelefonoResponsable,HorarioAtencionApertura,HorarioAtencionClausura")] ResponsableSucursal responsableSucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsableSucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsableSucursal);
        }

        // GET: ResponsableSucursal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResponsableSucursals == null)
            {
                return NotFound();
            }

            var responsableSucursal = await _context.ResponsableSucursals.FindAsync(id);
            if (responsableSucursal == null)
            {
                return NotFound();
            }
            return View(responsableSucursal);
        }

        // POST: ResponsableSucursal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResponsable,NombreResponsable,ApellidoResponsable,CargoResponsable,EmailResponsable,TelefonoResponsable,HorarioAtencionApertura,HorarioAtencionClausura")] ResponsableSucursal responsableSucursal)
        {
            if (id != responsableSucursal.IdResponsable)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsableSucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsableSucursalExists(responsableSucursal.IdResponsable))
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
            return View(responsableSucursal);
        }

        // GET: ResponsableSucursal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResponsableSucursals == null)
            {
                return NotFound();
            }

            var responsableSucursal = await _context.ResponsableSucursals
                .FirstOrDefaultAsync(m => m.IdResponsable == id);
            if (responsableSucursal == null)
            {
                return NotFound();
            }

            return View(responsableSucursal);
        }

        // POST: ResponsableSucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResponsableSucursals == null)
            {
                return Problem("Entity set 'AbmsucursalesContext.ResponsableSucursals'  is null.");
            }
            var responsableSucursal = await _context.ResponsableSucursals.FindAsync(id);
            if (responsableSucursal != null)
            {
                _context.ResponsableSucursals.Remove(responsableSucursal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsableSucursalExists(int id)
        {
          return (_context.ResponsableSucursals?.Any(e => e.IdResponsable == id)).GetValueOrDefault();
        }
    }
}
