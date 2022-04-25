using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        User GetByLogin(string login);
        User Create(string login, string password);
    }
}