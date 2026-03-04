using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreens
{
    public static class ListCategoriesWithPostsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias com quantidade de posts");
            Console.WriteLine("-------------------------------------------");
            List();
            Console.ReadKey();
            MenuReportsScreen.Load();
        }

        private static void List()
        {
            var repository = new CategoryRepository(Database.Connection);
            var categories = repository.ListCategoryPosts();
            foreach (var item in categories)
            {
                Console.WriteLine($"Categoria: {item.Name}");
                Console.WriteLine($" Posts: {item.Posts.Count}");
                Console.WriteLine();
            }
        }
    }
}