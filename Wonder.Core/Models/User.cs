using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wonder.Core.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede tener una longitud máxima de {1}.")]
        [Column("first_name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede tener una longitud máxima de {1}.")]
        [Column("second_name")]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(5, ErrorMessage = "El campo {0} solo puede tener una longitud máxima de {1}.")]
        [Column("mobile_phone")]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede tener una longitud máxima de {1}.")]
        [Column("home_phone")]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede tener una longitud máxima de {1}.")]
        [Column("email_address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="El campo {0} debe tener formato de correo.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(150, ErrorMessage = "El campo {0} solo puede tener una longitud máxima de {1}.")]
        [Column("primary_address")]
        [Display(Name = "Primary Address")]
        public string PrimaryAddress { get; set; }

        //[Required]
        //[ForeignKey("type_user")]
        [Column("type_user")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Rol")]
        public int RolId { get; set; }

        //[ForeignKey("RolId")]
        public Rol Rol { get; set; }
    }
}
