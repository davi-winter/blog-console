namespace Blog.Screens.UserRoleScreens
{
    public static class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular perfil/usuário");
            Console.WriteLine("-----------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar perfil/usuário");
            Console.WriteLine("2 - Cadastrar perfil/usuário");
            Console.WriteLine("3 - Excluir perfil/usuário");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListUserRoleScreen.Load();
                    break;
                case 2:
                    CreateUserRoleScreen.Load();
                    break;
                case 3:
                    DeleteUserRoleScreen.Load();
                    break;
                case 4:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}