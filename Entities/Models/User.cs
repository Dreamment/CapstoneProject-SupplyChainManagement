using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User : IdentityUser <Guid>
    {

        [MaxLength(240)]
        public string Role_Name { get; set; }

        public float Salary { get; set; }

        public bool Status { get; set; }

        public Supplier Supplier { get; set; }
    }
}
