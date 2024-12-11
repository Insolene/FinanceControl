using FinanceControl.Data.Repository.Interface;
using FinanceControl.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository category)
        {
            _categoryRepository = category;
        }
        [HttpGet, Route("all")]
        public async Task<ActionResult<List<CategoryEntities>>> Get()
        {
            List<CategoryEntities> entities = await _categoryRepository.GetAll();
            return Ok(entities);
        }
        [HttpGet, Route("id")]
        public async Task<ActionResult<CategoryEntities>> GetById(int id)
        {
            CategoryEntities entities = await _categoryRepository.GetById(id);
            return Ok(entities);
        }
        [HttpPost, Route("add")]
        public async Task<ActionResult<CategoryEntities>> Add([FromBody]CategoryEntities category)
        {
            CategoryEntities entities = await _categoryRepository.AddCategory(category);
            return Ok(entities);
        }
        [HttpPut, Route("update")]
        public async Task<ActionResult<CategoryEntities>> Update(CategoryEntities category, int id)
        {
            CategoryEntities entities = await _categoryRepository.UpdateCategory(category, id);            
            return Ok(entities);
        }
        [HttpDelete,Route("remove")]
        public async Task<ActionResult<CategoryEntities>> Delete(int id)
        {
            bool category = await _categoryRepository.DeleteCategory(id);
            return Ok(category);
        }
    }
}
