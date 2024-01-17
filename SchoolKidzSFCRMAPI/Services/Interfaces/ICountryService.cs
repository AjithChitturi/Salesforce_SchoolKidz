using SchoolkidzModels.OutputModels;

namespace SchoolKidzSFCRMAPI.Services.Interfaces
{
    public interface ICountryService
    {
        public Task<List<CountryOutModel>> GetCountryEntityData();
        
    }
}
