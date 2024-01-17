using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;

namespace SchoolKidzSFCRMAPI.Services.RequestLayer
{
    public interface IRequestService
    {
        public Task<string> Get(string take, bool idTake, string endPoint);
        public Task<string> Post(Dictionary<string, string> take, string endPoint);
        public Task<string> Delete(string take, string endPoint);
        public Task<bool> Put(string id, Dictionary<string, dynamic> model, string endPoint);
    }
}
