using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemarketing.Data.Entities
{
    [Table("Collects")]
    public class Collect
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("Indicator")]
        public int IndicatorId { get; set; }
        public Indicator? Indicator { get; set; }
    }
}
