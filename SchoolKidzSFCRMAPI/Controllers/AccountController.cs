using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;
using System.Text.Json.Serialization;


namespace SchoolKidzSFCRMAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountInController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountInController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // Post: api/<AccountInController>
        [HttpPost]
        public async Task<AccountOutModel> GetAccountData(AccountInModel accountIn)
        {
            if (accountIn == null || accountIn.Id == null)
                throw new Exception("Invalid model");
            return await _accountService.GetAccountData(accountIn, "Account/");
        }

        // Post api/<AccountInController>/5
        [HttpPost]
        public async Task<List<AccountOutModel>> GetAccountByUserId(SystemUserDropdownListModel accountIn)
        {
            if (accountIn == null || accountIn.systemuserid == null)
                throw new Exception("Invalid model");
            return await _accountService.GetAccountByUserId(accountIn, "/services/data/v58.0/query?q=");
        }

        //Post api/<AccountInController>
        [HttpPost]
        public async Task<bool> UpdateAccountEntityById(AccountInModel accountIn)
        {
            if (accountIn == null || accountIn.Id == null)
                throw new Exception("Invalid model");
            return await _accountService.UpdateAccountEntityById(accountIn,1);
        }

        //Post api/<AccountInController>
        [HttpPost]
        public async Task<bool> UpdateAccountData(AccountInModel accountIn)
        {
            if(accountIn == null || accountIn.Id == null)
                throw new Exception("Invalid model");
            return await _accountService.UpdateAccountEntityById(accountIn,2);
        }
        //Post api/<AccountInController>
        [HttpPost]
        public async Task<bool> UpdateAccountStatus(AccountInModel accountIn)
        {
            if (accountIn == null || accountIn.Id == null)
                throw new Exception("Invalid model");
            return await _accountService.UpdateAccountEntityById(accountIn,3);
        }
        //Post api/<AccountInController>
        [HttpPost]
        public async Task<SchoolEmailDataOutModel> GetSchoolEmailData(AccountInModel accountIn)
        {
            if (accountIn == null || accountIn.Id == null)
                throw new Exception("Invalid model");
            return await _accountService.GetSchoolEmailData(accountIn, "Account/");
        }

        [HttpPost]
        public async Task<List<AccountContactListOutModel>> GetAccountContactList(AccountContactListOutModel accountContactListOut)
        {
            if (accountContactListOut == null || accountContactListOut.accountId == null)
                throw new Exception("Invalid Model");
            return await _accountService.GetAccountContactList(accountContactListOut);
        }

        [HttpPost]
        public async Task<List<AccountOutModel>> AccountDetailsGet(AccountInModel input)
        {
            return await _accountService.AccountDetailsGet(input, "/services/data/v58.0/query?q=");
        }
        // PUT api/<AccountInController>/5
/*        [HttpPut]
        public async Task<bool> Put([FromBody] AccountInModel value)
        {
            return await _accountService.PutAccount(value.Id.ToString(), value, "/services/data/v58.0/sobjects/Account/");
        }*/
    }
}
