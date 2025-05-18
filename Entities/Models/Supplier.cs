using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Supplier
    {
        public string SupplierName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string ContactPerson { get; set; }

        public string Telephone { get; set; }

        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public string TaxId { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }

        public User User { get; set; }

        public List<Bid> Bids { get; set; }

        public List<TenderSupplier> TenderSuppliers { get; set; }
    }
}
