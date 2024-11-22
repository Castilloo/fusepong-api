using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FusepongAPI.Models;

namespace FusepongAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
    Task<User> Create(User user);
    Task<User> GetByEmail(string email);
    Task<User> GetUserById(int id);
    Task<int> GetCompanyIdByName(string name);
    }
}