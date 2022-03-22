#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARM_MVC.Data;
using MSPApplication.Shared.Models;

namespace ARM_MVC.Controllers
{
    public class AMenusController : Controller
    {
        private readonly ARM_MVCContext _context;

        public AMenusController(ARM_MVCContext context)
        {
            _context = context;
        }

        // GET: AMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AMenu.ToListAsync());
        }

        // GET: AMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aMenu = await _context.AMenu
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (aMenu == null)
            {
                return NotFound();
            }

            return View(aMenu);
        }

        // GET: AMenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,ParentId,Name,Order,Active,Url,Icon,Override")] AMenu aMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aMenu);
        }

        // GET: AMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aMenu = await _context.AMenu.FindAsync(id);
            if (aMenu == null)
            {
                return NotFound();
            }
            return View(aMenu);
        }

        // POST: AMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,ParentId,Name,Order,Active,Url,Icon,Override")] AMenu aMenu)
        {
            if (id != aMenu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AMenuExists(aMenu.MenuId))
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
            return View(aMenu);
        }

        // GET: AMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aMenu = await _context.AMenu
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (aMenu == null)
            {
                return NotFound();
            }

            return View(aMenu);
        }

        // POST: AMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aMenu = await _context.AMenu.FindAsync(id);
            _context.AMenu.Remove(aMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AMenuExists(int id)
        {
            return _context.AMenu.Any(e => e.MenuId == id);
        }
    }
}
