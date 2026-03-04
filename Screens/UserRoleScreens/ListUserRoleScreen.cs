using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public static class ListUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de perfil/usuário");
            Console.WriteLine("-----------------------");
            List();
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.ListUserRoles();
            foreach (var item in users)
            {
                if (item.Roles.Count == 0)
                    continue;

                Console.WriteLine($"Usuário: {item.Id} - {item.Name}");
                foreach (var role in item.Roles)
                    Console.WriteLine($" Perfil: {role.Id} - {role.Name}");
                Console.WriteLine();
            }
        }
    }
}