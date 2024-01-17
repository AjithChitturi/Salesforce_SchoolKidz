using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;

namespace SchoolKidzSFCRMAPI.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<AccountOutModel> GetAccountData(AccountInModel accountModel, string endPoint);
        public Task<List<AccountOutModel>> GetAccountByUserId(SystemUserDropdownListModel accountIn, string endPoint);
        public Task<bool> UpdateAccountEntityById(AccountInModel accountModel, int choice);
        public Task<SchoolEmailDataOutModel> GetSchoolEmailData(AccountInModel accountIn, string endPoint);
        public Task<List<AccountContactListOutModel>> GetAccountContactList(AccountContactListOutModel accountInModel);

        public Task<List<AccountOutModel>> AccountDetailsGet(AccountInModel accountIn, string endPoint);
    }
}
