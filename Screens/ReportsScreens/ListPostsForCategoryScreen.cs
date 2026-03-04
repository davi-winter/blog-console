using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportsScreens
{
    public static class ListPostsForCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts de uma categoria");
            Console.WriteLine("-------------------------------");
            Console.Write("Insira o Id da Categoria: ");
            int categoryId = int.Parse(Console.ReadLine()!);
            Console.Clear();
            List(categoryId);
            Console.ReadKey();
            MenuReportsScreen.Load();
        }

        private static void List(int categoryId)
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ListForCategory(categoryId);

            if (posts.Count == 0)
            {
                Console.WriteLine("Não existem posts para este Id de categoria");
                Console.WriteLine();
                return;
            }
            else
            {
                Console.WriteLine($"Categoria: {posts[0].Category}");
                Console.WriteLine();
            }

            foreach (var item in posts)
                Console.WriteLine($"Id: {item.Id}\nTítulo: {item.Title}\nResumo: {item.Summary}\nTexto: {item.Body}\nSlug: {item.Slug}\n" +
                    $"Data de criação: {item.CreateDate.ToLocalTime()}\nÚltima atualização: {item.LastUpdateDate.ToLocalTime()}\n");
        }
    }
}