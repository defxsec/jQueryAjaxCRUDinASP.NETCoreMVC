using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jQueryAjaxCRUDinASP.NETCoreMVC.Models;

namespace jQueryAjaxCRUDinASP.NETCoreMVC.Controllers
{
    public class TransaccionModelsController : Controller
    {
        private readonly TransaccionDbContext _context;

        public TransaccionModelsController(TransaccionDbContext context)
        {
            _context = context;
        }

        // GET: TransaccionModels
        public async Task<IActionResult> Index()
        {
              return _context.Transacciones != null ? 
                          View(await _context.Transacciones.ToListAsync()) :
                          Problem("Entity set 'TransaccionDbContext.Transacciones'  is null.");
        }

        // GET: TransaccionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccionModel = await _context.Transacciones
                .FirstOrDefaultAsync(m => m.TransaccionId == id);
            if (transaccionModel == null)
            {
                return NotFound();
            }

            return View(transaccionModel);
        }

        // GET: TransaccionModels/AddOrEdit
        // GET: TransaccionModels/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new TransaccionModel());
            else
            {
                var transactionModel = await _context.Transacciones.FindAsync(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }              

        // POST: TransaccionModels/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransaccionId,NumeroCuenta,NombreBeneficiario,NombreBanco,CodigoSWIFT,Monto,Fecha")] TransaccionModel transaccionModel)
        {           
            if (ModelState.IsValid)
            {
                if (id == 0) {
                    transaccionModel.Fecha = DateTime.Now;
                    _context.Add(transaccionModel);
                    await _context.SaveChangesAsync();
                }
                else {
                    try
                    {
                        _context.Update(transaccionModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransaccionModelExists(transaccionModel.TransaccionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transacciones.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transaccionModel) });
        }        

        // POST: TransaccionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Transacciones.FindAsync(id);
            _context.Transacciones.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transacciones.ToList()) });
        }

        private bool TransaccionModelExists(int id)
        {
          return (_context.Transacciones?.Any(e => e.TransaccionId == id)).GetValueOrDefault();
        }
    }
}
