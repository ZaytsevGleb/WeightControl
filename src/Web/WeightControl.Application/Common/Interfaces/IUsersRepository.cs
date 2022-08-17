using WeightControl.Domain.Entities;

namespace WeightControl.Application.Common.Interfaces
{
    public interface IUsersRepository
    {
        User GetByLogin(string login);
        User Create(User user);
    }
}