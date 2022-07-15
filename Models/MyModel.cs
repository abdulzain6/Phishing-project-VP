using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VpTaskWebApp.Models
{
    public class MyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set;}

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string? Username { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string? Password { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string? platform { get; set; }
    }


}
