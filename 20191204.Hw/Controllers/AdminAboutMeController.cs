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
    public class AdminAboutMeController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminAboutMeController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: AdminAboutMe
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutMe.ToListAsync());
        }

        // GET: AdminAboutMe/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: AdminAboutMe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminAboutMe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Paragraph")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                aboutMe.Id = Guid.NewGuid();
                _context.Add(aboutMe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: AdminAboutMe/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe.FindAsync(id);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        // POST: AdminAboutMe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Paragraph")] AboutMe aboutMe)
        {
            if (id != aboutMe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutMe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.Id))
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
            return View(aboutMe);
        }

        // GET: AdminAboutMe/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: AdminAboutMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aboutMe = await _context.AboutMe.FindAsync(id);
            _context.AboutMe.Remove(aboutMe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeExists(Guid id)
        {
            return _context.AboutMe.Any(e => e.Id == id);
        }
    }
}
