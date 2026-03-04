using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostTagScreens
{
    public static class ListPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de post/tag");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ListPostTags();
            foreach (var item in posts)
            {
                if (item.Tags.Count == 0)
                    continue;

                Console.WriteLine($"Post: {item.Id} - {item.Title}");
                foreach (var tag in item.Tags)
                    Console.WriteLine($" Tag: {tag.Id} - {tag.Name}");
                Console.WriteLine();
            }
        }
    }
}