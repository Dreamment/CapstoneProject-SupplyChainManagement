using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class RawMaterialData
    {
        public string CompanyBarcode { get; set; }

        public string OldBarcode { get; set; }

        public string Brand { get; set; }

        public string FabricComposition { get; set; }

        public string Color { get; set; }

        public float Amount { get; set; }

        public string Unit { get; set; }

        public float Price { get; set; }
    }

}
