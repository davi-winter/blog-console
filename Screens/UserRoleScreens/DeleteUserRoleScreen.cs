using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public static class DeleteUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir perfil/usuário");
            Console.WriteLine("----------------------");
            Console.Write("Informe o id do usuário: ");
            var userId = Console.ReadLine();

            Console.Write("Informe o id do perfil: ");
            var roleId = Console.ReadLine();

            DeleteUserRole(int.Parse(userId), int.Parse(roleId));

            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        private static void DeleteUserRole(int userId, int roleId)
        {
            var repository = new UserRepository(Database.Connection);
            repository.DeleteUserRole(userId, roleId);
            Console.WriteLine("Exclusão de vínculo realizado com sucesso");
        }
    }
}