using Entities;
using System.ComponentModel.DataAnnotations;

#nullable disable
namespace DTOs
{
    public class CreateUserDto
    {
        [StringLength(150, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.", MinimumLength = 2)]
        public string Nombre { get; set; }
        [StringLength(150, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.", MinimumLength = 2)]
        public string Apellido { get; set; }
        [EmailAddress(ErrorMessage ="El formato del {0} es incorrecto.")]
        public string Email { get;  set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }

        public static explicit operator User(CreateUserDto dto)
        {
            return new User(0, dto.Nombre, dto.Apellido, dto.Email, dto.Password);
        }
    }
}