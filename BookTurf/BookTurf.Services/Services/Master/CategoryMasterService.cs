using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookTurf.Data.Models;
using BookTurf.Services;
using BookTurf.Repository.Interfaces;
using BookTurf.Services.Interfaces;
using BookTurf.Services.Models;

namespace BookTurf.Services
{
    public class CategoryMasterService : EntityService<CategoryMaster>, ICategoryMasterService
    {
        private readonly ICategoryMasterRepository _categoryMasterRepository;
        public CategoryMasterService(IUnitOfWork unitOfWork, ICategoryMasterRepository repository) :
            base(unitOfWork, repository)
        {
            UnitOfWork = unitOfWork;
            _categoryMasterRepository = repository;
        }
        public Result<CategoryMaster> Add(CategoryMaster ar)
        {
            var res = new Result<CategoryMaster>()
            {
                IsSuccess = false,
                Errors = new List<String>(),
                Data = null
            };
            Create(ar);
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = ar;
            }
            return res;
        }
        public IEnumerable<CategoryMaster> GetAllTrue()
        {
            return _categoryMasterRepository.GetAllTrue();
        }
        public CategoryMaster GetById(int? categoryId)
        {
            return _categoryMasterRepository.GetById(categoryId);
        }
        public Result<CategoryMaster> Edit(int id, CategoryMaster ar)
        {
            var res = new Result<CategoryMaster>()
            {
                IsSuccess = false,
                Errors = new List<string>(),
                Data = null
            };

            Update(ar);
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = ar;
            }
            return res;

        }
        public bool? CheckDuplicate(string categoryName)
        {
            return _categoryMasterRepository.CheckDuplicate(categoryName);
        }

        public Result<CategoryMaster> Delete(int id)
        {
            var res = new Result<CategoryMaster>()
            {
                IsSuccess = false,
                Errors = new List<string>(),
                Data = null
            };
            var CategoryMaster = _categoryMasterRepository.GetById(id);
            if (CategoryMaster == null)
            {
                res.Errors.Add($"We could not find the CategoryMaster with id = {id.ToString()}");
                return res;
            }
            CategoryMaster.IsDeleted = true;
            Update(CategoryMaster);
            if (UnitOfWork.Commit() > 0)
            {
                res.IsSuccess = true;
                res.Data = CategoryMaster;
            }
            return res;

        }
    }
}
