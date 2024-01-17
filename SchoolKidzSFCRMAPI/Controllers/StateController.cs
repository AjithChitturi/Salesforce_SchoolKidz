using Microsoft.AspNetCore.Mvc;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolKidzSFCRMAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }
        [HttpPost]
        public async Task<List<StateProvinceOutModel>> GetStateProvinceEntityData()
        {
            return await _stateService.GetStateProvinceEntityData();
        }
    }
}
