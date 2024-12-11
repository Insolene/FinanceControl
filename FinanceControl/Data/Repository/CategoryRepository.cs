using FinanceControl.Data.Repository.Interface;
using FinanceControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Banco _banco;
        public CategoryRepository(Banco banco)
        {
            _banco = banco;
        }

        public async Task<List<CategoryEntities>> GetAll()
        {
            return await _banco.Categories.ToListAsync();
        }
        public async Task<CategoryEntities> GetById(int id)
        {
            return await _banco.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<CategoryEntities> AddCategory(CategoryEntities category)
        {
            await _banco.Categories.AddAsync(category);
            await _banco.SaveChangesAsync();
            return category;
        }
        public async Task<CategoryEntities> UpdateCategory(CategoryEntities category,int id)
        {
            CategoryEntities ctg = await GetById(id);
            if (ctg == null)
            {
                throw new Exception($"Categoria {id} não encontrada no banco de dados");
            }
            ctg.Name = category.Name;
            ctg.Id = category.Id;
            _banco.Categories.Add(category);
            await _banco.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            CategoryEntities category = await GetById(id);
            if (category == null)
            {
                throw new Exception($"Categoria {id} não encontrada no banco de dados");
            }
            _banco.Categories.Remove(category);
            await _banco.SaveChangesAsync();
            return true;
        }
        }
}
