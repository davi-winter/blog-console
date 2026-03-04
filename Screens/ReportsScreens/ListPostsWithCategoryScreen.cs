using Blog.Repositories;

namespace Blog.Screens.ReportsScreens
{
    public static class ListPostsWithCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de todos os posts com sua categoria");
            Console.WriteLine("-----------------------------------------");
            List();
            Console.ReadKey();
            MenuReportsScreen.Load();
        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ListWithCategoryAndAuthor();
            foreach (var item in posts)
                Console.WriteLine($"Id: {item.Id}\nCategoria: {item.Category}\n" +
                    $"Título: {item.Title}\nResumo: {item.Summary}\nTexto: {item.Body}\nSlug: {item.Slug}\n" +
                    $"Data de criação: {item.CreateDate.ToLocalTime()}\nÚltima atualização: {item.LastUpdateDate.ToLocalTime()}\n");
        }
    }
}