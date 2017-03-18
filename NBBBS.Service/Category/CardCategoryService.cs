using NBBBS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBBBS.Service.Category
{
    public class CardCategoryService : ICardCategoryService
    {
        private readonly NBBBSContext _context;
        public CardCategoryService(NBBBSContext context)
        {
            this._context = context;

        }
        public bool Add(CardCategory model)
        {
            try
            {
                model.CreateTime = DateTime.Now;
                _context.Add(model);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(CardCategory model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                var cardCategory = _context.CardCategory.SingleOrDefault(m => m.Id == Id);
                if (cardCategory == null)
                {
                    return false;
                }
                _context.CardCategory.Remove(cardCategory);
                _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(CardCategory model)
        {
            try
            {
                model.UpdateTime = DateTime.Now;
                _context.Update(model);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CardCategory> GetAll()
        {
            return _context.CardCategory.ToList();
        }

        public CardCategory GetById(int Id)
        {
            var cardCategory = _context.CardCategory.SingleOrDefault(m => m.Id == Id);
            return cardCategory;
        }

        public bool CardCategoryExists(int id)
        {
            return _context.CardCategory.Any(p => p.Id == id);
        }
    }
}
