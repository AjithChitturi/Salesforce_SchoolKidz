using Microsoft.AspNetCore.Mvc;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.Services;
using SchoolKidzSFCRMAPI.Services.Interfaces;


namespace SchoolKidzSFCRMAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuoteRequestController : ControllerBase
    {
        IQuoteRequestService _quoteRequestService;
        public QuoteRequestController(IQuoteRequestService quoteRequestService)
        {
            _quoteRequestService = quoteRequestService;
        }

        [HttpGet]
        public async Task<List<QReqGetOutModel>> GetQuotes()
        {
            return await _quoteRequestService.GetQuotes();
        }

        [HttpPost]
        public async Task<QReqGetOutModel> getEntityDataById(QReqGetOutModel Qmodel)
        {
            if (Qmodel == null || Qmodel.Id == null)
                throw new Exception("Invalid model");

            return await _quoteRequestService.getEntityDataById(Qmodel, "/services/data/v58.0/query?q=");
        }


        [HttpPost]
        public async Task<List<ExceptionOutModel>> GetExceptionApprovalRequest(NotesInModel notesInModel)
        {
            return await _quoteRequestService.GetExceptionApprovalRequestData(notesInModel);
        }

        [HttpPost]

        public async Task<bool> AssignQuoteRequest(QReqGetInModel model)
        {
            if (model == null || model.Id == null)
                throw new Exception("Invalid model");
            return await _quoteRequestService.updateQuoteEntityById(model, "Quote__c/");
        }





        [HttpPost]

       public async Task<bool> updateQuoteEntityById(QReqGetOutModel model)
       {
           
            return await _quoteRequestService.updateQuoteEntityById(model, "Quote__c/");
       }

        [HttpPost]

        public async Task<List<QReqGetOutModel>> GetQuoteRequestsFromCRM(QReqListInModel model)
        {
            return await _quoteRequestService.GetQuoteRequestsFromCRM(model, "Quote__c/");

        }


    }
}
