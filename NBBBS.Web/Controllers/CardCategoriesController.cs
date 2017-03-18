using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBBBS.Data;
using NBBBS.Service.Category;

namespace NBBBS.Web.Controllers
{
    public class CardCategoriesController : Controller
    {
        private readonly ICardCategoryService _ICardCategoryService;

        public CardCategoriesController(ICardCategoryService cardCategoryService)
        {
            _ICardCategoryService = cardCategoryService;
        }

        // GET: CardCategories
        public IActionResult Index()
        {
            var model = _ICardCategoryService.GetAll();

            return View(model);
        }

        // GET: CardCategories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCategory = _ICardCategoryService.GetById(id.Value);

            if (cardCategory == null)
            {
                return NotFound();
            }

            return View(cardCategory);
        }

        // GET: CardCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoryName,CreateTime,UpdateTime")] CardCategory cardCategory)
        {
            if (ModelState.IsValid)
            {
                _ICardCategoryService.Add(cardCategory);

                return RedirectToAction("Index");
            }
            return View(cardCategory);
        }

        // GET: CardCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCategory = _ICardCategoryService.GetById(id.Value);

            if (cardCategory == null)
            {
                return NotFound();
            }
            return View(cardCategory);
        }

        // POST: CardCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CategoryName,CreateTime,UpdateTime")] CardCategory cardCategory)
        {
            if (id != cardCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ICardCategoryService.Update(cardCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardCategoryExists(cardCategory.Id))
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
            return View(cardCategory);
        }

        // GET: CardCategories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardCategory = _ICardCategoryService.GetById(id.Value);

            if (cardCategory == null)
            {
                return NotFound();
            }

            return View(cardCategory);
        }

        // POST: CardCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ICardCategoryService.Delete(id);
            return RedirectToAction("Index");
        }

        private bool CardCategoryExists(int id)
        {
            return _ICardCategoryService.CardCategoryExists(id);
        }
    }
}
