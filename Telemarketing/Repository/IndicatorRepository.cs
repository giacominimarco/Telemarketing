using Microsoft.EntityFrameworkCore;
using Telemarketing.Data;
using Telemarketing.Data.Entities;
using Telemarketing.DTOs;

namespace Telemarketing.Repositories
{
    public class IndicatorRepository : IIndicatorRepository
    {
        private readonly ApplicationDbContext _context;

        public IndicatorRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<IndicatorDTO>> GetAll()
        {
            List<Indicator> indicators = await _context.Indicators
                .Include(indicators => indicators.Collects)
                .ToListAsync();

            return indicators.Select(indicator => new IndicatorDTO
            {
                Id = indicator.Id,
                Name = indicator.Name,
                TypeCalc = indicator.TypeCalc,
                Collects = indicator.Collects.Select(collect => new CollectDTO
                {
                    Id = collect.Id,
                    Value = collect.Value,
                    Date = collect.Date,
                    IndicatorId = collect.IndicatorId
                }).ToList(),
            }).ToList();
        }

        public async Task<IndicatorDTO> GetCalcByIndicatorId(int indicatorId)
        {
            Indicator indicator = await _context.Indicators
                .Include(i => i.Collects)
                .FirstOrDefaultAsync(i => i.Id == indicatorId);

            if (indicator == null) return new IndicatorDTO();

            IndicatorDTO dto = new IndicatorDTO
            {
                Id = indicator.Id,
                Name = indicator.Name,
                Description = indicator.Description,
                TypeCalc = indicator.TypeCalc,
                Collects = indicator.Collects.Select(collect => new CollectDTO
                {
                    Id = collect.Id,
                    Value = (float)collect.Value,
                    Date = collect.Date,
                    IndicatorId = collect.IndicatorId
                }).ToList()
            };

            dto.Calculate();

            return dto;
        }

        public async Task<bool> Create(IndicatorDTO indicator)
        {
            try
            {
                await _context.Indicators.AddAsync(new Indicator
                {
                    Name = indicator.Name,
                    TypeCalc = indicator.TypeCalc,
                    Collects = indicator.Collects.Select(c => new Collect
                    {
                        IndicatorId = indicator.Id,
                        Value = c.Value,
                        Date = c.Date == null ? DateTime.Now : c.Date
                    }).ToList()
                });
                
                await _context.SaveChangesAsync();
             
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCollect(CollectUpdateDTO collectUpdate)
        {
            try
            {
                int rowsAffected = await _context.Collects
                    .Where(c => c.Id == collectUpdate.Id)
                    .ExecuteUpdateAsync(c => c.SetProperty(c => c.Value, collectUpdate.Value));
                
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
