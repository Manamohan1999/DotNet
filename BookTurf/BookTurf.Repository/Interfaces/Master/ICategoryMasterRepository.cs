using BookTurf.Data.Models;
using BookTurf.Repository.Interfaces;
using System.Collections.Generic;

namespace BookTurf.Repository.Interfaces
{
    public interface ICategoryMasterRepository : IGenericRepository<CategoryMaster>
    {
        IEnumerable<CategoryMaster> GetAllTrue();
        CategoryMaster GetById(int? categoryId);
        bool? CheckDuplicate(string categoryName);
    }
}
