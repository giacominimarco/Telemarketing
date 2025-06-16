using Telemarketing.Data.Enums;

namespace Telemarketing.DTOs
{
    public class IndicatorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public TypeCalc TypeCalc { get; set; }
        public double CalcValue { get; set; }

        public List<CollectDTO> Collects { get; set; } = new List<CollectDTO>();

        public void Calculate()
        {
            if (TypeCalc == TypeCalc.Soma)
            {
                if (this.Collects == null || this.Collects.Count == 0)
                {
                    this.CalcValue = 0.0;
                    return;
                }
                this.CalcValue = this.Collects.Sum(c => c.Value);
            }
            else if (TypeCalc == TypeCalc.Media)
            {
                if (this.Collects == null || this.Collects.Count == 0)
                {
                    this.CalcValue = 0.0;
                    return;
                }
                this.CalcValue = (this.Collects.Count > 0 ? this.Collects.Average(c => c.Value) : 0.0);
            }
        }
    }
}
