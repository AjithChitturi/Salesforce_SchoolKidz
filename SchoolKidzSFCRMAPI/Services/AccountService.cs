using Newtonsoft.Json;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;
using System.Collections;
using System.Diagnostics;

namespace SchoolKidzSFCRMAPI.Services
{
    public class AccountService : IAccountService
    {
        IRequestService _RequestService { get; set; }
        ILogger<AccountService> _logger;
        public AccountService(IRequestService requestService, ILogger<AccountService> logger)
        {
            _RequestService = requestService;
            _logger = logger;
        }

        public async Task<AccountOutModel> GetAccountData(AccountInModel accountModel, string endPoint)
        {
            _logger.LogInformation("Account/GET: Start ");
            var timer = new Stopwatch();
            timer.Start();
            Dictionary<string,object> dictResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(accountModel.Id,true,endPoint));
            Dictionary<string,object> dictContact = null, coodEmail = null, repEmail = null;
            if (dictResponse["PrimaryContact__c"] != null)
                dictContact = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(dictResponse["PrimaryContact__c"].ToString(), true, "Contact/"));
            if (dictResponse["tt_salescoordinatorid__c"] != null)
                coodEmail = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(dictResponse["tt_salescoordinatorid__c"].ToString(), true, "User/"));
            if (dictResponse["tt_salesrepid__c"] != null)
                repEmail = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(dictResponse["tt_salesrepid__c"].ToString(), true, "User/"));
            AccountOutModel outModel = new AccountOutModel()
            {
                accountnumber = dictResponse["AccountNumber"].ToString(),
                primarycontactid = dictResponse["PrimaryContact__c"].ToString(),
                accountId = accountModel.Id,
                name = dictResponse["Name"].ToString(),
                schoolemailaddress = dictContact["Email"].ToString() == null ? "" : dictContact["Email"].ToString(),
                salescoordinatoremailaddress = coodEmail["Email"].ToString(),
                salesrepemailaddress = repEmail["Email"].ToString()
            };

            timer.Stop();
            _logger.LogInformation($"Account/GET: Time taken {timer.Elapsed.TotalSeconds.ToString("0.000")}");
            return outModel;
        }

        public async Task<List<AccountOutModel>> GetAccountByUserId(SystemUserDropdownListModel accountIn, string endPoint)
        {
            var query = $"SELECT Id,Name FROM Account WHERE UserId__c='{accountIn.systemuserid}'";
            var ret = JsonConvert.DeserializeObject<UserIdGetModel>(await _RequestService.Get(query, false, endPoint));
            List<AccountOutModel> accountList = new List<AccountOutModel>();
            foreach (var item in ret.records)
            {
                AccountOutModel model = new AccountOutModel();
                model.accountId = item["Id"];
                model.name = item["Name"];
                accountList.Add(model);
            }
            return accountList;  
        }

        public async Task<bool> UpdateAccountEntityById(AccountInModel accountModel,int choice)
        {
            Dictionary<string, dynamic> model;
            if (choice == 1)
            {
                model = new Dictionary<string, dynamic>();
                model["address1_line1__c"] = accountModel.address1_line1;
                model["address1_line2__c"] = accountModel.address1_line2;
                model["address1_line3__c"] = accountModel.address1_line3;
                model["Name"] = accountModel.name;
                model["tt_status_number__c"] = accountModel.tt_status_number;
                model["tt_StatementName__c"] = accountModel.tt_StatementName;
                model["address1_city__c"] = accountModel.address1_city;
                model["BillingPostalCode"] = accountModel.address1_postalcode;
                model["Address1_Telephone1__c"] = accountModel.Address1_Telephone1;
                model["telephone1__c"] = accountModel.telephone1;
                model["tt_enrollment__c"] = accountModel.tt_enrollment;
                model["tt_GPUpdateFlag__c"] = accountModel.tt_GPUpdateFlag;
                model["tt_grades__c"] = accountModel.tt_grades;
                model["tt_taxexcemptexpirationdate__c"] = accountModel.tt_taxexcemptexpirationdate;
                model["tt_taxexemptinfo__c"] = accountModel.tt_taxexemptinfo;
            }

            else if (choice == 2)
            {
                model = new Dictionary<string, dynamic>();
                model["tt_programschedulecomplete__c"] = accountModel.tt_programschedulecomplete;

            }

            else if (choice == 3)
            {
                model = new Dictionary<string, dynamic>();
                model["tt_status_number__c"] = accountModel.tt_status_number ??= 0;
            }

            else
            {
                throw new Exception("Not a valid Put choice");
            }
            return await _RequestService.Put(accountModel.Id, model, "Account");
        }

        public async Task<SchoolEmailDataOutModel> GetSchoolEmailData(AccountInModel accountIn,string endPoint)
        {
            Dictionary<string, object> dictResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(accountIn.Id, true, endPoint));
            Dictionary<string, object> dictContact = null, coodEmail = null, repEmail = null;
            if (dictResponse["PrimaryContact__c"] !=null)
                dictContact = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(dictResponse["PrimaryContact__c"].ToString(), true, "/services/data/v58.0/sobjects/Contact/"));
            if (dictResponse["tt_salescoordinatorid__c"] != null)
                coodEmail = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(dictResponse["tt_salescoordinatorid__c"].ToString(), true, "/services/data/v58.0/sobjects/User/"));
            if (dictResponse["tt_salesrepid__c"] != null)
                repEmail = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(dictResponse["tt_salesrepid__c"].ToString(), true, "/services/data/v58.0/sobjects/User/"));

            SchoolEmailDataOutModel schoolEmailDataOutModel = new SchoolEmailDataOutModel();
            schoolEmailDataOutModel.accountid = accountIn.Id;
            schoolEmailDataOutModel.accountnumber = dictResponse["AccountNumber"].ToString();
            schoolEmailDataOutModel.name = dictResponse["Name"].ToString();
            schoolEmailDataOutModel.schoolemailaddress = dictContact["Email"].ToString() == null ? "" : dictContact["Email"].ToString();
            schoolEmailDataOutModel.salescoordinatoremailaddress = coodEmail["Email"].ToString();
            schoolEmailDataOutModel.salesrepemailaddress = repEmail["Email"].ToString();
            return schoolEmailDataOutModel;
        }

        public async Task<List<AccountContactListOutModel>> GetAccountContactList(AccountContactListOutModel accountInModel)
        {
            List<AccountContactListOutModel> accountContactListOutModel = new List<AccountContactListOutModel>();
            var InResponse = await _RequestService.Get($"{accountInModel.accountId}/AccountContactRelations/", true, "Account/");
            AccountContactModel SerialResponse = JsonConvert.DeserializeObject<AccountContactModel>(InResponse);
            AccountContactListOutModel accountContact = new AccountContactListOutModel();
            accountContact.accountId = accountInModel.accountId;
            accountContact.contactGetListOutModel = new List<ContactGetListOutModel>();
            foreach(var i in SerialResponse.records)
            {
                ContactGetListOutModel addListOut = new ContactGetListOutModel();
                var dictContact = JsonConvert.DeserializeObject<Dictionary<string, object>>(await _RequestService.Get(i.ContactId, true, "Contact/"));
                addListOut.contactid = i.ContactId;
                addListOut.telephone1 = dictContact["Phone"]?.ToString();
                addListOut.firstName = dictContact["FirstName"]?.ToString();
                addListOut.lastName = dictContact["LastName"]?.ToString();
                addListOut.fullName = dictContact["Name"]?.ToString();
                addListOut.emailaddress = dictContact["Email"]?.ToString();
                accountContact.contactGetListOutModel.Add(addListOut);
            }
            accountContactListOutModel.Add(accountContact);
            return accountContactListOutModel;
        }
        public async Task<List<AccountOutModel>> AccountDetailsGet(AccountInModel accountIn, string endPoint)
        {
            List<AccountOutModel> accountOutModels = new List<AccountOutModel>();
            string accountnumber = "";
            for(int i = 0; i < accountIn.accountnumber.Length; i++)
            {
                if (i != accountIn.accountnumber.Length - 1)
                {
                    accountnumber += $"'{accountIn.accountnumber[i]}' OR AccountNumber=";
                }
                else
                {
                    accountnumber += $"'{accountIn.accountnumber[i]}'";
                }
            }
            var query = $"SELECT Name, tt_grades__c, PrimaryContact__c, AccountNumber FROM Account WHERE AccountNumber=" + accountnumber;

            var Accounts = JsonConvert.DeserializeObject<AccountDropDownNew>(await _RequestService.Get(query, false, endPoint));

            for (int i = 0; i < (Accounts?.records?.Length ?? 0); i++)
            {
                AccountModelNew item = Accounts?.records?[i]??new AccountModelNew();
                accountOutModels.Add(new AccountOutModel
                {
                    name = item.Name,
                    tt_grades = item.tt_grades__c,
                    primarycontactid = item.PrimaryContact__c,
                    accountnumber = item.AccountNumber
                });
            }
            return accountOutModels;
        }
    }
}
