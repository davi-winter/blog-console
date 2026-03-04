using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreens
{
    public static class ListTagsWithPostsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listas tags com quantidade de posts");
            Console.WriteLine("-----------------------------------");
            List();
            Console.ReadKey();
            MenuReportsScreen.Load();
        }

        private static void List()
        {
            var repository = new TagRepository(Database.Connection);
            var tags = repository.ListTagPosts();
            foreach (var item in tags)
            {
                Console.WriteLine($"Tag: {item.Name}");
                Console.WriteLine($" Posts: {item.Posts.Count}");
                Console.WriteLine();
            }
        }
    }
}