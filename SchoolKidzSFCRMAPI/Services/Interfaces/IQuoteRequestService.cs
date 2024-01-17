using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;

namespace SchoolKidzSFCRMAPI.Services.Interfaces
{
    public interface IQuoteRequestService
    {
        public Task<List<ExceptionOutModel>> GetExceptionApprovalRequestData(NotesInModel model);

        public Task<QReqGetOutModel> getEntityDataById(QReqGetOutModel Qmodel, string endPoint);

        public Task<bool> updateQuoteEntityById(QReqGetOutModel model, string endPoint);

        public Task<List<QReqGetOutModel>> GetQuoteRequestsFromCRM(QReqListInModel model, string endPoint);
        public Task<bool> updateQuoteEntityById(QReqGetInModel model, string endPoint);
        public Task<List<QReqGetOutModel>> GetQuotes();
    }
}
