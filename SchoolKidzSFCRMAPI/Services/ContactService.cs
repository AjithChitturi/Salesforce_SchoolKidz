using Newtonsoft.Json;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;

namespace SchoolKidzSFCRMAPI.Services
{
    public class ContactService : IContactService
    {
        IRequestService _requestService;
        public ContactService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task<ContactOutModel> GetAccountData(ContactInModel contactInModel)
        {
            var response = await _requestService.Get(contactInModel.contactid[0], true, "Contact/");
            if (response == null)
                throw new Exception("Did not find resource: Contact");
            var contactResponse = JsonConvert.DeserializeObject<ContactModelNew>(response);
            response = await _requestService.Get(contactResponse.AccountId, true, "Account/");
            var accountResponse = JsonConvert.DeserializeObject<AccountModelNew>(response);

            ContactOutModel output = new ContactOutModel
            {
                contactid = contactResponse.Id,
                fullname = contactResponse.Name,
                firstName = contactResponse.FirstName,
                lastName = contactResponse.LastName,
                account_name = accountResponse.Name,
                account_tt_enrollment = accountResponse.tt_enrollment__c,
                account_accountid = contactResponse.AccountId,
                account_AccountNumber = accountResponse.AccountNumber,
                account_address1_city = accountResponse.address1_city__c,
                account_address1_line1 = accountResponse.address1_line1__c,
                account_address1_line2 = accountResponse.address1_line2__c,
                account_address1_line3 = accountResponse.address1_line3__c,
                account_address1_postalcode = accountResponse.BillingPostalCode,
                account_Address1_Telephone1 = accountResponse.Address1_Telephone1__c,
                account_telephone1 = accountResponse.telephone1__c,
                account_tt_GPUpdateFlag = accountResponse.tt_GPUpdateFlag__c,
                account_tt_grades = accountResponse.tt_grades__c,
                account_tt_programschedulecomplete = accountResponse.tt_programschedulecomplete__c,
                account_tt_statementname = accountResponse.tt_StatementName__c,
                account_tt_taxexcemptexpirationdate = accountResponse.tt_taxexcemptexpirationdate__c??=new DateTime(),
                account_tt_taxexemptinfo = accountResponse.tt_taxexemptinfo__c,
                telephone1 = contactResponse.Phone,
                emailaddress1 = contactResponse.Email,
                //11 fields missing
            };

            return output;
        }

        public async Task<List<ContactDropdownListModel>> GetContactEntityData(AccountInModel accountInModel)
        {
            var query = $"SELECT Id,Name FROM Contact WHERE AccountId='{accountInModel.Id}'";
            var jsonString = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");
            var ret = JsonConvert.DeserializeObject<ContactDropDownNew>(jsonString);
            List<ContactDropdownListModel> result = new List<ContactDropdownListModel>();
            for (int i = 0;i<ret.records.Length;i++)
            {
                result.Add(new ContactDropdownListModel { ContactId = ret.records[i].Id, FullName = ret.records[i].Name });
            }
            return result;
        }
    }
}
