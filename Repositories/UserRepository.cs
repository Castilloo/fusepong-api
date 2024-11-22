using FusepongAPI.Models;
using FusepongAPI.Models.Context;
using FusepongAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FusepongAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly FusepongContext _context;
        public UserRepository(FusepongContext context) => _context = context;
        public async Task<User> Create(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error save user ", ex);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(user => user.Email == email) 
                    ?? throw new Exception("user not found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error get user ", ex);
            }
            
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(user => user.UserId == id)
                    ?? throw new Exception("User not found");;
            }
            catch (Exception ex)
            {
                throw new Exception("Error get user ", ex);
            }
        }

        public async Task<int> GetCompanyIdByName(string name) 
        {
            try
            {
                return await _context.Companies
                    .Where(c => c.Name == name)
                    .Select(c => c.CompanyId)
                    .FirstOrDefaultAsync();    
            }
            catch (Exception ex)
            {
                throw new Exception("Error get company id ", ex);
            }
        }
    }
}