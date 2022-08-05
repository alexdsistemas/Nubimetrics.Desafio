namespace Entities
{
    public class User
    {

        public User(int id, string nombre, string apellido, string email, string password)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}