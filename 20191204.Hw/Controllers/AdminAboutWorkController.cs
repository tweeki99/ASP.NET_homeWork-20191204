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
    public class AdminAboutWorkController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminAboutWorkController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: AdminAboutWork
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutWork.ToListAsync());
        }

        // GET: AdminAboutWork/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutWork = await _context.AboutWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutWork == null)
            {
                return NotFound();
            }

            return View(aboutWork);
        }

        // GET: AdminAboutWork/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminAboutWork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Text")] AboutWork aboutWork)
        {
            if (ModelState.IsValid)
            {
                aboutWork.Id = Guid.NewGuid();
                _context.Add(aboutWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutWork);
        }

        // GET: AdminAboutWork/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutWork = await _context.AboutWork.FindAsync(id);
            if (aboutWork == null)
            {
                return NotFound();
            }
            return View(aboutWork);
        }

        // POST: AdminAboutWork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Year,Text")] AboutWork aboutWork)
        {
            if (id != aboutWork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutWorkExists(aboutWork.Id))
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
            return View(aboutWork);
        }

        // GET: AdminAboutWork/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutWork = await _context.AboutWork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutWork == null)
            {
                return NotFound();
            }

            return View(aboutWork);
        }

        // POST: AdminAboutWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aboutWork = await _context.AboutWork.FindAsync(id);
            _context.AboutWork.Remove(aboutWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutWorkExists(Guid id)
        {
            return _context.AboutWork.Any(e => e.Id == id);
        }
    }
}
