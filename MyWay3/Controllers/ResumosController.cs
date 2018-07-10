using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWay3.Models;

namespace MyWay3.Controllers
{
    public class ResumosController : Controller
    {
        private readonly MywayDbContext _context;

        public ResumosController(MywayDbContext context)
        {
            _context = context;
        }

        // GET: Resumos       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resumo.ToListAsync());
        }

        // GET: Resumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resumo = await _context.Resumo
                .FirstOrDefaultAsync(m => m.IdResumo == id);
            if (resumo == null)
            {
                return NotFound();
            }

            return View(resumo);
        }

        // GET: Resumos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resumos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResumo,DataResumo,StaffEscala,StaffDuty,TotalAssistencias,IncumprimentosSla,EquipamentosOkVta,EquipamentosOkAmbulift,EquipamentosInopVta,EquipamentosInopAmbulift,TotalVoos,AtrasosImputados,AtrasosAceites")] Resumo resumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resumo);
                await _context.SaveChangesAsync();
            }
            return View(resumo);
        }

        // GET: Resumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resumo = await _context.Resumo.FindAsync(id);
            if (resumo == null)
            {
                return NotFound();
            }
            return View(resumo);
        }

        // POST: Resumos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResumo,DataResumo,StaffEscala,StaffDuty,TotalAssistencias,IncumprimentosSla,EquipamentosOkVta,EquipamentosOkAmbulift,EquipamentosInopVta,EquipamentosInopAmbulift,TotalVoos,AtrasosImputados,AtrasosAceites")] Resumo resumo)
        {
            if (id != resumo.IdResumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumoExists(resumo.IdResumo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(resumo);
        }

        // GET: Resumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resumo = await _context.Resumo
                .FirstOrDefaultAsync(m => m.IdResumo == id);
            if (resumo == null)
            {
                return NotFound();
            }

            return View(resumo);
        }

        // POST: Resumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resumo = await _context.Resumo.FindAsync(id);
            _context.Resumo.Remove(resumo);
            await _context.SaveChangesAsync();
        }

        private bool ResumoExists(int id)
        {
            return _context.Resumo.Any(e => e.IdResumo == id);
        }
    }
}
