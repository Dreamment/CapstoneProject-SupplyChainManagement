using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [MaxLength(240)]
        public string Supplier_Name { get; set; }

        [MaxLength(240)]
        public string Address { get; set; }

        [MaxLength(40)]
        public string Country { get; set; }

        [MaxLength(150)]
        public string Contact_Person { get; set; }

        [MaxLength(40)]
        public string Telephone { get; set; }


        [MaxLength(240)]
        public string E_Mail { get; set; }


        [MaxLength(40)]
        public string Tax_ID { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(150)]
        public string User_Name { get; set; }

        public List<Bid> Bids { get; set; }
    }

}
