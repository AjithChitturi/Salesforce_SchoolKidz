using Newtonsoft.Json;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;
using System.Reflection;

namespace SchoolKidzSFCRMAPI.Services
{
    public class QuoteRequestService : IQuoteRequestService
    {
        IRequestService _requestService;
        public QuoteRequestService(IRequestService requestService)
        {
            _requestService = requestService;
        }


        public async Task<List<QReqGetOutModel>> GetQuotes()
        {
            var query = "SELECT Id, Name FROM Quote__c";
            var jsonResponse = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");

            var recordObject = JsonConvert.DeserializeObject<QuoteListModel>(jsonResponse);

            var QuoteList = new List<QReqGetOutModel>();

            foreach (var record in recordObject.records)
            {
                var Quote = new QReqGetOutModel
                {
                    Id = record.Id,
                    LogicalName = record.Name,
                };

                QuoteList.Add(Quote);
            }

            return QuoteList;

        }

        public async Task<QReqGetOutModel> getEntityDataById(QReqGetOutModel Qmodel, string endPoint)
        {
            var query = $"SELECT Id FROM Quote__c WHERE Id='{Qmodel.Id}'";
            var res = JsonConvert.DeserializeObject<QuoteListModel>(await _requestService.Get(query, false, endPoint));

            var item = res.records[0]; // Assuming you expect only one record in the result list

            QReqGetOutModel model = new QReqGetOutModel();

            model.Id = item.Id;
            

            return model;
        }






        public async Task<List<ExceptionOutModel>> GetExceptionApprovalRequestData(NotesInModel model)
        {
            List<ExceptionOutModel> models = new List<ExceptionOutModel> ();
            var noteResponse = JsonConvert.DeserializeObject<Dictionary<string,dynamic>>(await _requestService.Get(model.Id,true, "Note/"));
            var exceptionApprovalResponse = JsonConvert.DeserializeObject<ExceptionListModel>(await _requestService.Get($"SELECT Id FROM ExceptionApprovalRequest__c WHERE tt_Account__c = '{noteResponse["ParentId"]}'", false, "/services/data/v58.0/query?q="));

            foreach (var val in exceptionApprovalResponse.records)
            {
                var exceptionDetailResponse = JsonConvert.DeserializeObject<ExceptionApprovalModel>(await _requestService.Get(val.Id, true, "ExceptionApprovalRequest__c/"));
                models.Add(new ExceptionOutModel
                {
                    Account = exceptionDetailResponse.tt_Account__c,
                    ApprovalRequestDate = exceptionDetailResponse.tt_ApprovalRequestDate__c,
                    ApproveDenyDate = exceptionDetailResponse.tt_ManagerApproveDenyDate__c,
                    Exceptionapprovalrequestid = exceptionDetailResponse.Id,
                    Status = exceptionDetailResponse.tt_Status__c,
                    Manager = exceptionDetailResponse.tt_AssignedManager__c,
                    RequestNotes = exceptionDetailResponse.tt_RequestNotes__c,
                    ResponseNotes = exceptionDetailResponse.tt_ResponseNotes__c
                });
            }
            return models;
        }

        public async Task<List<QReqGetOutModel>> GetQuoteRequestsFromCRM(QReqListInModel model, string endPoint)
        {
            var query = $"SELECT Id,Name,tt_Account__c,tt_RequestType__c,tt_ResponseNotes__c,tt_SpecialNotes__c FROM Quote__c";
            var response = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");
            var record = JsonConvert.DeserializeObject<QuoteListModel>(response);

            var quoteRequests = new List<QReqGetOutModel>();

                foreach (var i in record.records)
                {
                    var Omodel = new QReqGetOutModel
                    {
                        AccountName = i.tt_Account__c,
                        RequestType = i.tt_RequestType__c,
                        specialNotes = i.tt_SpecialNotes__c,
                        responseNotes = i.tt_ResponceNotes__c
                    };

                    quoteRequests.Add(Omodel);
                }

                return quoteRequests;

        }



        public async Task<bool> updateQuoteEntityById(QReqGetOutModel model, string endPoint)
        {
            Dictionary<string, dynamic> Qmodel = new Dictionary<string, dynamic>();

            Qmodel["tt_status__c"] = model.statusId;
            Qmodel["tt_responsenotes__c"] = model.responseNotes;


            return await _requestService.Put(model.Id, Qmodel, "Quote__c/");
        }

        public async Task<bool> updateQuoteEntityById(QReqGetInModel model, string endPoint)
        {
            Dictionary<string, dynamic> Qmodel = new Dictionary<string, dynamic>();

            Qmodel["tt_status__c"] = "Completed";
            Qmodel["tt_AssignedDate__c"] = "DateTime.Now";
            
            return await _requestService.Put(model.Id, Qmodel, "Quote__c/");
        }
    }
}
