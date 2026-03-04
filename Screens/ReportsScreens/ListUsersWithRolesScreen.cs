using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreens
{
    public static class ListUserWithRolesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista dos usuários (Nome, Email e perfis)");
            Console.WriteLine("-----------------------------------------");
            List();
            Console.ReadKey();
            MenuReportsScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.ListUserRoles();
            foreach (var item in users)
            {
                string roles = string.Empty;
                if (item.Roles.Count > 0)
                {
                    foreach (var role in item.Roles)
                        roles = roles + role.Name + ", ";
                    roles = roles.Substring(0, roles.Length - 2);
                }
                else
                    roles = "--Sem perfil--";

                Console.WriteLine($"{item.Name} - {item.Email} ({roles})");

                Console.WriteLine();
            }
        }
    }
}