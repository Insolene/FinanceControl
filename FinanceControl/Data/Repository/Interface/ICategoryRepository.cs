using FinanceControl.Entities;

namespace FinanceControl.Data.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<List<CategoryEntities>> GetAll();
        Task<CategoryEntities> GetById(int id);
        Task<CategoryEntities> AddCategory(CategoryEntities category);
         Task<CategoryEntities> UpdateCategory(CategoryEntities category, int id);
         Task<bool> DeleteCategory(int id);
    }
}
