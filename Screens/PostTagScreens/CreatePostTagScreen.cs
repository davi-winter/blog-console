using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostTagScreens
{
    public static class CreatePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar post/tag");
            Console.WriteLine("------------------");
            Console.Write("Informe o id do post: ");
            var postId = Console.ReadLine();

            Console.Write("Informe o id da tag: ");
            var tagId = Console.ReadLine();

            CreatePostTag(int.Parse(postId), int.Parse(tagId));

            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        private static void CreatePostTag(int postId, int tagId)
        {
            var repository = new PostRepository(Database.Connection);
            repository.CreatePostTag(postId, tagId);
            Console.WriteLine("Cadastro de vínculo realizado com sucesso");
        }
    }
}