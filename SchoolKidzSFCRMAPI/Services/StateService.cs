using Newtonsoft.Json;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;

namespace SchoolKidzSFCRMAPI.Services
{
    public class StateService : IStateService
    {
        IRequestService _requestService;
        public StateService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task<List<StateProvinceOutModel>> GetStateProvinceEntityData()
        {
            List<StateProvinceOutModel> stateProvinceOuts = new List<StateProvinceOutModel>();
            var response = await _requestService.Get("", true, "Account/describe");
            var allFields = JsonConvert.DeserializeObject<StateFilterModel>(response);
            int i;
            for(i = 0;i<allFields.fields.Length;i++)
            {
                if (allFields.fields[i].name == "BillingStateCode")
                    break;
            }

            for(int j = 0; j < allFields.fields[i].picklistValues.Length; j++)
            {
                if (allFields.fields[i].picklistValues[j].validFor == "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAA")
                {
                    StateProvinceOutModel add = new StateProvinceOutModel
                    {
                        state_province_name = allFields.fields[i].picklistValues[j].label,
                        state_province_id = allFields.fields[i].picklistValues[j].value
                    };
                    stateProvinceOuts.Add(add);
                }
            }
            return stateProvinceOuts;
        }
    }
}
