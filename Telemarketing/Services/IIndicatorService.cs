using Telemarketing.DTOs;

namespace Telemarketing.Services
{
    public interface IIndicatorService
    {
        Task<List<IndicatorDTO>> GetAll();
        Task<IndicatorDTO> GetCalcByIndicatorId(int indicatorId);
        Task<bool> Create(IndicatorDTO indicator);
        Task<bool> UpdateCollect(CollectUpdateDTO collectUpdate);
    }
}
