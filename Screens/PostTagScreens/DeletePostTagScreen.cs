using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostTagScreens
{
    public static class DeletePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir post/tag");
            Console.WriteLine("----------------");
            Console.Write("Informe o id do post: ");
            var postId = Console.ReadLine();

            Console.Write("Informe o id da tag: ");
            var tagId = Console.ReadLine();

            DeletePostTag(int.Parse(postId), int.Parse(tagId));

            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        private static void DeletePostTag(int postId, int tagId)
        {
            var repository = new PostRepository(Database.Connection);
            repository.DeletePostTag(postId, tagId);
            Console.WriteLine("Exclusão de vínculo realizado com sucesso");
        }
    }
}