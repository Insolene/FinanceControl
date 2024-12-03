using FinanceControl.Data.Repository.Interface;
using FinanceControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Banco _banco;
        public UserRepository(Banco banco) 
        {
            _banco = banco;
        }
        public async Task<List<UserEntities>> GetAll()
        {
            return await _banco.Users.ToListAsync() ;
        }
        public async Task<UserEntities> GetByName(string name)
        {
            return await _banco.Users.FirstOrDefaultAsync(x => x.Name ==name);
        }public async Task<UserEntities> GetById(int id)
        {
            return await _banco.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserEntities> AddUser(UserEntities user)
        {
             await _banco.Users.AddAsync(user);
            await _banco.SaveChangesAsync();
            return user;
        }
        public async Task<UserEntities>UpdateUser(UserEntities user, int id)
        {
            UserEntities userEntities = await GetById(user.Id);
            if (userEntities == null) 
            {
                throw new Exception($"Usuário:{id} não encontrado no banco de dados!");
            }
            userEntities.Name = user.Name;
            userEntities.Password = user.Password;
            _banco.Users.Update(user);
            await _banco.SaveChangesAsync();
            return userEntities;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserEntities userEntities = await GetById(id);
            if (userEntities == null)
            {
                throw new Exception($"Usuário:{id} não encontrado no banco de dados!");
            }
            _banco.Users.Remove(userEntities);
            await _banco.SaveChangesAsync();
            return true;
        }
    }
}
