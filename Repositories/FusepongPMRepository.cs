using System.Runtime.Intrinsics.X86;
using FusepongAPI.Models;
using FusepongAPI.Models.Context;
using FusepongAPI.Models.Dtos;
using FusepongAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FusepongAPI.Repositories
{
    public class FusepongPMRepository : IFusepongPMRepository
    {
        private readonly FusepongContext _context;

        public FusepongPMRepository(FusepongContext context)
        {
            _context = context;
        }

        private async Task<User> GetUser(int id)
        {
            try
            {
                return await _context.Users
                    .Where(u => u.UserId == id)
                    .FirstOrDefaultAsync() ?? new User();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users", ex);
            }
        }

        public async Task<UserDto> GetUserById(int id)
        {
            try
            {
                var company = await GetCompanyByUserId(id);
                return await _context.Users
                    .Where(u => u.UserId == id)
                    .Select(u => new UserDto
                    {
                        UserId = u.UserId,
                        Name = u.Name,
                        Email = u.Email,
                        Company = company
                    }).FirstOrDefaultAsync() ?? new UserDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users", ex);
            }
        }

        public async Task<CompanyDto> GetCompanyByUserId(int userId)
        {
            try
            {
                var user = await GetUser(userId);
                return await _context.Companies
                    .Where(c => c.CompanyId == user.CompanyId)
                    .Select(c => new CompanyDto
                    {
                        CompanyId = c.CompanyId,
                        Name = c.Name,
                        Nit = c.Nit,
                        Phone = c.Phone,
                        Address = c.Address,
                        Email = c.Email,
                    }).FirstOrDefaultAsync() ?? new CompanyDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users", ex);
            }
        }

        public async Task<List<ProjectDto>> GetProjectsByCompanyId(int companyId)
        {
            try
            {
                return await _context.Projects
                    .Where(p => p.CompanyId == companyId)
                    .Select(p => new ProjectDto
                    {
                        ProjectId = p.ProjectId,
                        Name = p.Name,
                        CreationDate = p.CreationDate,
                        EndDate = p.EndDate,
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users", ex);
            }
        }
        public async Task<List<UserStoryDto>> GetStoriesByProjectId(int projectId)
        {
            try
            {

                return await _context
                .UserStories
                .Where(s => s.ProjectId == projectId)
                .Select(s => new UserStoryDto
                {
                    StoryId = s.StoryId,
                    Name = s.Name,
                    Description = s.Description,
                    CreationDate = s.CreationDate,
                    EndDate = s.EndDate,
                    User = s.User!.Name ?? "-",
                    Tickets = s.Tickets
                        .Where(t => t.StoryId == s.StoryId)
                        .Select(t => new TicketDto{
                            TicketId = t.TicketId,
                            Name = t.Name,
                            Description = t.Description,
                            Status = t.Status!.Name,
                            User = t.User!.Name
                    }).ToList(),
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stories", ex);
            }
        }

        private async Task<List<TicketDto>> GetTicketsByStory(int storyId)
        {
            try{
                return await _context
                .Tickets
                .Where(t => t.StoryId == storyId)
                .Select(t => new TicketDto
                {
                    TicketId = t.TicketId,
                    Name = t.Name,
                    Description = t.Description,
                    Status = t.Status!.Name,
                    // StoryId = t.StoryId,
                    User = t.User!.Name ?? ""
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stories", ex);
            }
        }

        public async Task<TicketDto> GetTicketDetails(int ticketId)
        {
            try
            {
                var comments = await GetCommentsByTicketId(ticketId);
                return await _context
                .Tickets
                .Where(t => t.TicketId == ticketId)
                .Select(t => new TicketDto
                {
                    TicketId = t.TicketId,
                    Name = t.Name,
                    Description = t.Description,
                    Status = t.Status!.Name,
                    StoryId = t.StoryId,
                    User = t.User!.Name ?? "",
                    Comments = comments
                }).FirstOrDefaultAsync() ?? new TicketDto();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving ticket", ex);
            }
        }

        public async Task<List<string?>> GetCompanyNames()
        {
            try
            {
                return await _context.Companies.Select(c => c.Name).ToListAsync() ?? [];
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error get companies", ex);

            }
        }

        private async Task<List<CommentDto>> GetCommentsByTicketId(int ticketId)
        {
            return await _context.Comments
                .Where(c => c.TicketId == ticketId)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    CommentText = c.CommentText,
                    CreationDate = c.CreationDate,
                    User = c.User!.Name ?? ""
                }).ToListAsync();
        }


    }
}
