namespace Blog.Screens.ReportsScreens
{
    public static class MenuReportsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatórios");
            Console.WriteLine("----------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar os usuários (Nome, Email e perfis)");
            Console.WriteLine("2 - Listas categorias com quantidade de posts");
            Console.WriteLine("3 - Listar tags com quantidade de posts");
            Console.WriteLine("4 - Listar os posts de uma categoria");
            Console.WriteLine("5 - Listar todos os posts com sua categoria");
            Console.WriteLine("6 - Listar os posts com suas tags");
            Console.WriteLine("7 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListUserWithRolesScreen.Load();
                    break;
                case 2:
                    ListCategoriesWithPostsScreen.Load();
                    break;
                case 3:
                    ListTagsWithPostsScreen.Load();
                    break;
                case 4:
                    ListPostsForCategoryScreen.Load();
                    break;
                case 5:
                    ListPostsWithCategoryScreen.Load();
                    break;
                case 6:
                    ListPostsWithTagsScreen.Load();
                    break;
                case 7:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}