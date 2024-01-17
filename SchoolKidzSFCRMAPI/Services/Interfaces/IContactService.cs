using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;

namespace SchoolKidzSFCRMAPI.Services.Interfaces
{
    public interface IContactService
    {
        public Task<ContactOutModel> GetAccountData(ContactInModel contactInModel);
        public Task<List<ContactDropdownListModel>> GetContactEntityData(AccountInModel accountInModel);

    }
}
