using Entities;

namespace DTOs
{

#nullable disable
    public class GetAllUserDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public static explicit operator User(GetAllUserDto dto)
        {
            return new User(dto.Id, dto.Nombre, dto.Apellido, dto.Email, "");
        }

        public static explicit operator GetAllUserDto(User dto)
        {
            return new GetAllUserDto 
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
            };
        }
    }
}
