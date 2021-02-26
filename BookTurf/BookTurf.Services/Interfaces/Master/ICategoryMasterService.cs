using System;
using System.Collections.Generic;
using System.Text;
using BookTurf.Data.Models;
using BookTurf.Services.Interfaces;

namespace BookTurf.Services.Interfaces
{
    public interface ICategoryMasterService : IEntityService<CategoryMaster>
    {
        IEnumerable<CategoryMaster> GetAllTrue();
        CategoryMaster GetById(int? categoryId);
        bool? CheckDuplicate(string categoryName);
    }
}
