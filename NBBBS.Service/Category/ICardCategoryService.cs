using NBBBS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBBBS.Service.Category
{
    public interface ICardCategoryService
    {
        CardCategory GetById(int Id);
        bool Add(CardCategory model);
        bool Delete(CardCategory model);
        bool Delete(int Id);
        bool Update(CardCategory model);
        bool CardCategoryExists(int id);

        List<CardCategory> GetAll();
    }
}
