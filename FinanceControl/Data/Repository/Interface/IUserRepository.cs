using FinanceControl.Entities;

namespace FinanceControl.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserEntities>> GetAll();
        Task<UserEntities> GetByName(string name);
        Task<UserEntities> GetById(int id);
        Task<UserEntities> AddUser(UserEntities user);
        Task<UserEntities> UpdateUser(UserEntities user, int id);
        Task<bool> DeleteUser(int id);
    }
}
