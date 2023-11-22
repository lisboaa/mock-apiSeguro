using Seguro.Dominio.Entidades;

namespace Seguro.Dominio.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new() { Id = 1, UserName = "lisboa", Password = "lisboa", Role = "manager"},
                new() { Id = 2, UserName = "souza", Password = "souza", Role = "employee"},
            };
            return users.FirstOrDefault(x => string.Equals(x.UserName, username, StringComparison.CurrentCultureIgnoreCase) && x.Password == password);
        }
    }
}
