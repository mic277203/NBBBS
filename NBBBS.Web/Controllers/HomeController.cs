using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBBBS.Data;

namespace NBBBS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly NBBBSContext _context;

        public HomeController(NBBBSContext context)
        {
            _context = context;    
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var nBBBSContext = _context.Card.Include(c => c.CardCategory).Include(c => c.SysUser);
            return View(await nBBBSContext.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.CardCategory)
                .Include(c => c.SysUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            ViewData["CardCategoryId"] = new SelectList(_context.CardCategory, "Id", "CategoryName");
            ViewData["SysUserId"] = new SelectList(_context.SysUsers, "Id", "UserCode");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,CardCategoryId,SysUserId,CreateTime,UpdateTime")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CardCategoryId"] = new SelectList(_context.CardCategory, "Id", "CategoryName", card.CardCategoryId);
            ViewData["SysUserId"] = new SelectList(_context.SysUsers, "Id", "UserCode", card.SysUserId);
            return View(card);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card.SingleOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            ViewData["CardCategoryId"] = new SelectList(_context.CardCategory, "Id", "CategoryName", card.CardCategoryId);
            ViewData["SysUserId"] = new SelectList(_context.SysUsers, "Id", "UserCode", card.SysUserId);
            return View(card);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,CardCategoryId,SysUserId,CreateTime,UpdateTime")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CardCategoryId"] = new SelectList(_context.CardCategory, "Id", "CategoryName", card.CardCategoryId);
            ViewData["SysUserId"] = new SelectList(_context.SysUsers, "Id", "UserCode", card.SysUserId);
            return View(card);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.CardCategory)
                .Include(c => c.SysUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Card.SingleOrDefaultAsync(m => m.Id == id);
            _context.Card.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }
    }
}
