using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ActiveInvoiceList
    {
        public int ActiveInvoiceListId { get; set; }

        public int InvoiceId { get; set; }

        [MaxLength(40)]
        public string Barcode { get; set; }

        public int Quantity { get; set; }
    }

}
