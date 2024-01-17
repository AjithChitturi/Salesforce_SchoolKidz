using SchoolkidzModels.OutputModels;

namespace SchoolKidzSFCRMAPI.Services.Interfaces
{
    public interface IStateService
    {
        public Task<List<StateProvinceOutModel>> GetStateProvinceEntityData();
    }
}
