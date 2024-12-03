using FinanceControl.Data;
using FinanceControl.Data.Repository;
using FinanceControl.Data.Repository.Interface;
using FinanceControl.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }
        [HttpGet, Route("All")]
        public async Task<ActionResult<List<UserEntities>>> GetAllUsers()
        {
            List<UserEntities> users = await _userRepository.GetAll();
            return Ok(users);
        }
        [HttpGet, Route("Nome")]
        public async Task<ActionResult<UserEntities>> GetByName(string name)
        {
           UserEntities users = await _userRepository.GetByName(name);
            return Ok(users);
        }
        [HttpGet, Route("Id")]
        public async Task<ActionResult<UserEntities>> GetById(int id)
        {
           UserEntities users = await _userRepository.GetById(id);
            return Ok(users);
        }
        [HttpPost,Route("Add")]
        public async Task<ActionResult<UserEntities>> Add([FromBody] UserEntities user)
        {
            UserEntities userAdd = await _userRepository.AddUser(user);
            return Ok(userAdd);
        }
        [HttpPut,Route("Update")]
        public async Task<ActionResult<UserEntities>> Update([FromBody] UserEntities user, int id)
        {
            UserEntities userUp = await _userRepository.UpdateUser(user, id);
            return Ok(userUp);
        }
        [HttpDelete]
        public async Task<ActionResult<UserEntities>> Delete(int id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }

    } 
}
