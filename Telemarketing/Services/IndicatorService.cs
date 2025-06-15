using Telemarketing.Data.Entities;
using Telemarketing.DTOs;
using Telemarketing.Repositories;

namespace Telemarketing.Services
{
    public class IndicatorService : IIndicatorService
    {
        private readonly IIndicatorRepository _indicatorRepository;

        public IndicatorService(IIndicatorRepository indicatorRepository)
        {
            _indicatorRepository = indicatorRepository;
        }

        public Task<List<IndicatorDTO>> GetAll()
        {
            return _indicatorRepository.GetAll();
        }

        public Task<IndicatorDTO> GetCalcByIndicatorId(int indicatorId)
        {
            return _indicatorRepository.GetCalcByIndicatorId(indicatorId);
        }

        public Task<bool> Create(IndicatorDTO indicator)
        {
            return _indicatorRepository.Create(indicator);
        }

        public Task<bool> UpdateCollect(CollectUpdateDTO collectUpdate)
        {
            return _indicatorRepository.UpdateCollect(collectUpdate);
        }
    }
}
