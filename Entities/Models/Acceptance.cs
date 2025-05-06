using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Acceptance")]
    public class Acceptance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Acceptance_ID { get; set; }

        [MaxLength(80)]
        public string Purchase_Order_ID { get; set; }

        public int Invoice_ID { get; set; }

        public int Multi_User { get; set; }

        [MaxLength(80)]
        public string Acceptance_Status { get; set; }

        public int Invoice_Total { get; set; }

        public int Accepted_Total { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime Finish_Time { get; set; }

        [MaxLength(150)]
        public string User_Name { get; set; }
    }

}
