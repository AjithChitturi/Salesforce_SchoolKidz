using Microsoft.AspNetCore.Mvc;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolKidzSFCRMAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        //POST: api/[controller]
        [HttpPost]
        public async Task<ContactOutModel> GetAccountData(ContactInModel model)
        {
            return await _contactService.GetAccountData(model);
        }
        [HttpPost]
        public async Task<List<ContactDropdownListModel>> GetContactEntityData(AccountInModel accountInModel)
        {
            return await _contactService.GetContactEntityData(accountInModel);
        }
    }
}
