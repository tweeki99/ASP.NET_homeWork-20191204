using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _20191204.Hw.DataAcces;
using _20191204.Hw.Models;

namespace _20191204.Hw.Controllers
{
    public class AdminAboutStudyController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminAboutStudyController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: AboutStudies
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutStudy.ToListAsync());
        }

        // GET: AboutStudies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutStudy = await _context.AboutStudy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutStudy == null)
            {
                return NotFound();
            }

            return View(aboutStudy);
        }

        // GET: AboutStudies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Text")] AboutStudy aboutStudy)
        {
            if (ModelState.IsValid)
            {
                aboutStudy.Id = Guid.NewGuid();
                _context.Add(aboutStudy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutStudy);
        }

        // GET: AboutStudies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutStudy = await _context.AboutStudy.FindAsync(id);
            if (aboutStudy == null)
            {
                return NotFound();
            }
            return View(aboutStudy);
        }

        // POST: AboutStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Year,Text")] AboutStudy aboutStudy)
        {
            if (id != aboutStudy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutStudy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutStudyExists(aboutStudy.Id))
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
            return View(aboutStudy);
        }

        // GET: AboutStudies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutStudy = await _context.AboutStudy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutStudy == null)
            {
                return NotFound();
            }

            return View(aboutStudy);
        }

        // POST: AboutStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aboutStudy = await _context.AboutStudy.FindAsync(id);
            _context.AboutStudy.Remove(aboutStudy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutStudyExists(Guid id)
        {
            return _context.AboutStudy.Any(e => e.Id == id);
        }
    }
}
