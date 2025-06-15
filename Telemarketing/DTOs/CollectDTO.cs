namespace Telemarketing.DTOs
{
    public class CollectDTO
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int IndicatorId { get; set; }
        
    }
}
