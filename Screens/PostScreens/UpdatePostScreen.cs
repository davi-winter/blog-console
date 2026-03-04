using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um post");
            Console.WriteLine("-------------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Id da categoria: ");
            var categoryId = Console.ReadLine();

            Console.Write("Id do autor: ");
            var authorId = Console.ReadLine();

            Console.Write("Título: ");
            var title = Console.ReadLine();

            Console.Write("Resumo: ");
            var summary = Console.ReadLine();

            Console.Write("Texto: ");
            var body = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var lastUpdateDate = DateTime.UtcNow;

            Update(new Post
            {
                Id = int.Parse(id),
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                LastUpdateDate = lastUpdateDate
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}