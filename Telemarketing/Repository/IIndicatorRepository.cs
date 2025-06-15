using Telemarketing.Data.Entities;
using Telemarketing.DTOs;

namespace Telemarketing.Repositories
{
    public interface IIndicatorRepository
    {
        Task<List<IndicatorDTO>> GetAll();
        Task<IndicatorDTO> GetCalcByIndicatorId(int indicatorId);
        Task<bool> Create(IndicatorDTO indicator);
        Task<bool> UpdateCollect(CollectUpdateDTO collectUpdate);
    }
}
