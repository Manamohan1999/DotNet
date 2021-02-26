using BookTurf.Data.Models;
using BookTurf.Repository;
using BookTurf.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookTurf.Repository
{
    public class CategoryMasterRepository : GenericRepository<CategoryMaster>, ICategoryMasterRepository
    {
        public CategoryMasterRepository(BookTurfContext context) : base(context)
        {
        }
        public IEnumerable<CategoryMaster> GetAllTrue()
        {
            var categoryList = Context.CategoryMaster.Where(x => x.IsStatus == true && x.IsDeleted == false).ToList();
            return categoryList;
        }
        public CategoryMaster GetById(int? categoryId)
        {
            var categoryDetails = Context.CategoryMaster.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            return categoryDetails;
        }
        public bool? CheckDuplicate(string categoryName)
        {
            var isExist = Context.CategoryMaster.Where(x => x.CategoryName == categoryName && x.IsStatus==true && x.IsDeleted==false).Any();
            return isExist;
        }
    }
}
