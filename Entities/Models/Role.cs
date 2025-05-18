using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Role : IdentityRole<Guid>
    {
        public bool Buyer { get; set; }

        public bool Analitics { get; set; }

        public bool PreAcceptancePC { get; set; }

        public bool PreAcceptanceHand { get; set; }

        public bool AcceptancePC { get; set; }

        public bool AcceptanceHand { get; set; }

        public bool ShipmentBagPC { get; set; }

        public bool ShipmentBagHand { get; set; }

        public bool PickingPC { get; set; }

        public bool PickingHand { get; set; }

        public bool CarriagePC { get; set; }

        public bool CarriageHand { get; set; }

        public bool Reports { get; set; }

        public bool Parameters { get; set; }
    }

}
