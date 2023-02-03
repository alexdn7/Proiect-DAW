using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;

namespace Proiect_DAW.Repositories.UsersRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User FindByUsername(string username);   
    }
}
