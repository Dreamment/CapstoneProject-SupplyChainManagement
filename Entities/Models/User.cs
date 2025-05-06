using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Users")]
    public class User 
    {
        [Key]
        [MaxLength(150)]
        public string User_Name { get; set; }

        [MaxLength(40)]
        public string Password { get; set; }

        [MaxLength(40)]
        public string Telephone { get; set; }

        [MaxLength(240)]
        public string E_Mail { get; set; }

        [MaxLength(240)]
        public string Role_Name { get; set; }

        public float Salary { get; set; }

        public bool Status { get; set; }
    }

}
