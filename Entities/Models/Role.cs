using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [MaxLength(240)]
        public string Role_Name { get; set; }

        public bool Buyer { get; set; }

        public bool Analitics { get; set; }

        public bool PreAcceptance_PC { get; set; }

        public bool PreAcceptance_Hand { get; set; }

        public bool Acceptance_PC { get; set; }

        public bool Acceptance_Hand { get; set; }

        public bool Shipment_Bag_PC { get; set; }

        public bool Shipment_Bag_Hand { get; set; }

        public bool Picking_PC { get; set; }

        public bool Picking_Hand { get; set; }

        public bool Carriage_PC { get; set; }

        public bool Carriage_Hand { get; set; }

        public bool Reports { get; set; }

        public bool Parameters { get; set; }
    }

}
