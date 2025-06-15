using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telemarketing.Data.Enums;

namespace Telemarketing.Data.Entities
{
    [Table("Indicators")]
    public class Indicator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public TypeCalc TypeCalc { get; set; }
        public ICollection<Collect> Collects { get; set; } = new List<Collect>();
    }
}
