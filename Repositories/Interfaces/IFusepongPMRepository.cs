using FusepongAPI.Models;
using FusepongAPI.Models.Dtos;

namespace FusepongAPI.Repositories.Interfaces
{
    public interface IFusepongPMRepository
    {
        Task<UserDto> GetUserById(int id);
        Task<CompanyDto> GetCompanyByUserId(int userId);
        Task<List<ProjectDto>> GetProjectsByCompanyId(int companyId);
        Task<List<UserStoryDto>> GetStoriesByProjectId(int projectId);
        Task<TicketDto> GetTicketDetails(int ticketId);
        Task<List<string?>> GetCompanyNames();

    }
}