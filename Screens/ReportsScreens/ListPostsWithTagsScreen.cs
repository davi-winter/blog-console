using Blog.Repositories;

namespace Blog.Screens.ReportsScreens
{
    public static class ListPostsWithTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista os posts com suas tags");
            Console.WriteLine("----------------------------");
            List();
            Console.ReadKey();
            MenuReportsScreen.Load();
        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ListPostTags();
            foreach (var item in posts)
            {
                string tags = string.Empty;
                if (item.Tags.Count > 0)
                {
                    foreach (var tag in item.Tags)
                        tags = tags + tag.Name + ", ";
                    tags = tags.Substring(0, tags.Length - 2);
                }
                else
                    tags = "--Sem tag--";
                Console.WriteLine($"Id: {item.Id}\nTags: ({tags})\n" +
                    $"Título: {item.Title}\nResumo: {item.Summary}\nTexto: {item.Body}\nSlug: {item.Slug}\n" +
                    $"Data de criação: {item.CreateDate.ToLocalTime()}\nÚltima atualização: {item.LastUpdateDate.ToLocalTime()}\n");
            }
        }
    }
}