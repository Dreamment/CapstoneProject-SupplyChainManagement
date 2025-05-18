using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ActiveAcceptanceControl
    {
        public int ActiveAcceptanceControlId { get; set; }

        public int AcceptanceId { get; set; }

        public string Barcode { get; set; }

        public int InvoiceQuantity { get; set; }

        public int Accepted_Quantity { get; set; }
    }

}
