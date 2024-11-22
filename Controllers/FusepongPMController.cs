using FusepongAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FusepongAPI.Controllers
{
    [ApiController]
    [Route("api/fusepong")]
    public class FusepongPMController : Controller
    {
        private readonly IFusepongPMRepository _repository;
        private readonly ILogger<FusepongPMController> _logger;

        public FusepongPMController(ILogger<FusepongPMController> logger, IFusepongPMRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user =  await _repository.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching user");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("company-by-user/{userId}")]
        public async Task<IActionResult> GetCompanyByUserId(int userId)
        {
            try
            {
                var company =  await _repository.GetCompanyByUserId(userId);
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching company");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("projects-by-company/{companyId}")]
        public async Task<IActionResult> GetProjectsByCompanyId(int companyId)
        {
            try
            {
                var projects =  await _repository.GetProjectsByCompanyId(companyId);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching projects");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("stories-by-project/{projectId}")]
        public async Task<IActionResult> GetStoriesByProjectId(int projectId)
        {
            try
            {
                var stories =  await _repository.GetStoriesByProjectId(projectId);
                return Ok(stories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching stories");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("ticket-details/{id}")]
        public async Task<IActionResult> GetTicketDetails(int id)
        {
            try
            {
                var stories =  await _repository.GetTicketDetails(id);
                return Ok(stories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching stories");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies =  await _repository.GetCompanyNames();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching stories");
                return StatusCode(500, "Internal server error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}