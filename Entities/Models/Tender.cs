using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Tenders")]
    public class Tender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TenderID { get; set; }

        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public Status Status { get; set; }

        public List<Bid> Bids { get; set; }

        public List<TenderSupplier> TenderSuppliers { get; set; }
    }
}
