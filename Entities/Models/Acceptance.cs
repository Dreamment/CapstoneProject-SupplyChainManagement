using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Acceptance
    {
        public int AcceptanceId { get; set; }

        public string PurchaseOrderId { get; set; }

        public int InvoiceId { get; set; }

        public int MultiUser { get; set; }

        public string AcceptanceStatus { get; set; }

        public int InvoiceTotal { get; set; }

        public int AcceptedTotal { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public string Username { get; set; }
    }

}
