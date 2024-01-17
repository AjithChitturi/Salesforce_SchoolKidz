using Newtonsoft.Json;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using SchoolKidzSFCRMAPI.Services.RequestLayer;

namespace SchoolKidzSFCRMAPI.Services
{
    public class CountryService : ICountryService
    {
        IRequestService _requestService;
        public CountryService(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task<List<CountryOutModel>> GetCountryEntityData()
        {
            List<CountryOutModel> countryOutModels = new List<CountryOutModel>();
            var response = await _requestService.Get("", true, "Account/describe");
            var allFields = JsonConvert.DeserializeObject<StateFilterModel>(response);
            int i;
            for (i = 0; i < allFields.fields.Length; i++)
            {
                if (allFields.fields[i].name == "BillingCountryCode")
                    break;
            }
            for (int j = 0; j < allFields.fields[i].picklistValues.Length; j++)
            {
                CountryOutModel add = new CountryOutModel
                {
                    tt_country = allFields.fields[i].picklistValues[j].label,
                    tt_countryid = allFields.fields[i].picklistValues[j].value
                };
                countryOutModels.Add(add);
            }
            return countryOutModels;
        }
    }
}
