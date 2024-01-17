using Microsoft.AspNetCore.Mvc;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolKidzSFCRMAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost]
        public async Task<List<CountryOutModel>> GetCountryEntityData()
        {
            return await _countryService.GetCountryEntityData();
        }
    }
}
