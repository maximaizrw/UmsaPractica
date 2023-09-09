using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Umsa.Models
{
    public class User
    {
        [Column("codUsuario")]
        public int Id { get; set; }
        [Required]
        [Column("user_firstName", TypeName = "VARCHAR(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column("user_lastName", TypeName = "VARCHAR(100)")]
        public string LastName { get; set; }
        [Required]
        [Column("user_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }
        [Required]
        [Column("user_clave", TypeName = "VARCHAR(50)")]
        public string Clave { get; set; }
    }
}
