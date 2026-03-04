using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Blog.Screens.UserRoleScreens;
using Blog.Screens.PostTagScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Screens.ReportsScreens;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            // using var connection = new SqlConnection(CONNECTION_STRING);
            // var repository = new Repository<User>(connection);
            Database.Connection = new SqlConnection(CONNECTION_STRING);

            Database.Connection.Open();

            Load();
            //ReadUsersWithAuthors(Database.Connection);
            //ReadUsersWithRoles(Database.Connection);

            Console.ReadKey();
            Database.Connection.Close();
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("--------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuários");
            Console.WriteLine("2 - Gestão de perfis");
            Console.WriteLine("3 - Gestão de categorias");
            Console.WriteLine("4 - Gestão de tags");
            Console.WriteLine("5 - Gestão de posts");
            Console.WriteLine("6 - Vincular perfil/usuário");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine("8 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;
                case 6:
                    MenuUserRoleScreen.Load();
                    break;
                case 7:
                    MenuPostTagScreen.Load();
                    break;
                case 8:
                    MenuReportsScreen.Load();
                    break;
                default: Load(); break;
            }
        }

        private static void CreateUser(Repository<User> repository)
        {
            var user = new User
            {
                //Id = 1,
                Bio = "8x Microsoft MVP",
                Email = "andre@balta.io",
                Image = "https://balta.io/andrebaltieri.jpg",
                Name = "André Baltieri",
                Slug = "andre-baltieri",
                PasswordHash = Guid.NewGuid().ToString()
            };

            repository.Create(user);

            Console.WriteLine("Usuário criado: " + user.Name);
        }

        private static void UpdateUser(Repository<User> repository)
        {
            var user = repository.Read(1);
            user.Email = "hello@balta.io";
            repository.Update(user);

            Console.WriteLine(user?.Email);
        }

        private static void DeleteUser(Repository<User> repository)
        {
            var user = repository.Read(1);
            repository.Delete(user);

            Console.WriteLine("Usuário deletado: " + user.Name);
        }

        private static void ReadUser(Repository<User> repository)
        {
            var user = repository.Read(1);
            Console.WriteLine(user.Name);
        }

        /*private static void ReadUsers(Repository<User> repository)
        {
            var users = repository.Read();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }*/

        static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.ListUserRoles();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        static void ReadUsersWithAuthors(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.ListUserAuthors();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
    }
}
