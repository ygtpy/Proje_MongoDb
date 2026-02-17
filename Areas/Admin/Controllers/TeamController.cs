using AkademiQMongoDb.DTOs.TeamDtos;
using AkademiQMongoDb.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _teamService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            await _teamService.CreateAsync(createTeamDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTeam(string id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(string id)
        {
            var value = await _teamService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            await _teamService.UpdateAsync(updateTeamDto);
            return RedirectToAction("Index");
        }
    }
}
