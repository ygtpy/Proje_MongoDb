using AkademiQMongoDb.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultViewComponents
{
    public class DefaultTeamViewComponent : ViewComponent
    {
        private readonly ITeamService _teamService;

        public DefaultTeamViewComponent(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _teamService.GetAllAsync();
            return View(values);
        }
    }
}
