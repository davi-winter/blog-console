using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public static class CreateUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar perfil/usuário");
            Console.WriteLine("------------------------");
            Console.Write("Informe o id do usuário: ");
            var userId = Console.ReadLine();

            Console.Write("Informe o id do perfil: ");
            var roleId = Console.ReadLine();

            CreateUserRole(int.Parse(userId), int.Parse(roleId));

            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        private static void CreateUserRole(int userId, int roleId)
        {
            var repository = new UserRepository(Database.Connection);
            repository.CreateUserRole(userId, roleId);
            Console.WriteLine("Cadastro de vínculo realizado com sucesso");
        }
    }
}