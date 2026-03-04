namespace Blog.Screens.PostTagScreens
{
    public static class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular post/tag");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar post/tag");
            Console.WriteLine("2 - Cadastrar post/tag");
            Console.WriteLine("3 - Excluir post/tag");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListPostTagScreen.Load();
                    break;
                case 2:
                    CreatePostTagScreen.Load();
                    break;
                case 3:
                    DeletePostTagScreen.Load();
                    break;
                case 4:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}