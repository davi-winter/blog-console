using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class ListAuthorsPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de autores");
            Console.WriteLine("----------------");
            List();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var authors = repository.ListUserAuthors();
            foreach (var item in authors)
                Console.WriteLine($"{item.Id} - {item.Name}");
        }
    }
}