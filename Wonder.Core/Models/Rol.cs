using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wonder.Core.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        [Column("id")]
        public int RolId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("name")]
        public string Name { get; set; }

        public virtual  List<User> Users { get; set; }
    }
}