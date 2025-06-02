using Entities.DataTransferObjects.Home;

namespace MVCApp.Models
{
    public class HomeViewModel
    {
        public string RoleName { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public SupplierHomeGetTendersDTO SupplierHomeGetTendersDTO { get; set; } = new SupplierHomeGetTendersDTO();
        public AdminHomeGetTendersDTO AdminHomeGetTendersDTO { get; set; } = new AdminHomeGetTendersDTO();
    }
}
