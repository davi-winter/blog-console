using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;
        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public void CreatePostTag(int postId, int tagId)
        {
            var sql = "INSERT INTO [PostTag] ([PostId], [TagId]) VALUES (@PostId, @TagId)";

            _connection.Execute(sql, new { PostId = postId, TagId = tagId });
        }

        public void DeletePostTag(int postId, int tagId)
        {
            var sql = "DELETE FROM [PostTag] WHERE [PostId] = @PostId AND [TagId] = @TagId";

            _connection.Execute(sql, new { PostId = postId, TagId = tagId });
        }

        public List<Post> ListWithCategoryAndAuthor()
        {
            var query = @"SELECT
                            [Post].*,
                            [Category].[Name] AS [Category],
                            [User].[Name] AS [Author]
                        FROM 
                            [Post]
                            INNER JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
                            INNER JOIN [User] ON [User].[Id] = [Post].[AuthorId]";

            var posts = new List<Post>();

            var items = _connection.Query<Post>(query);

            foreach (var item in items)
                posts.Add(item);

            return posts;
        }

        public List<Post> ListForCategory(int categoryId)
        {
            var query = @"SELECT
                            [Post].*,
                            [Category].[Name] AS [Category]
                        FROM 
                            [Post]
                            INNER JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
                        WHERE [Post].[CategoryId] = @CategoryId";

            var posts = new List<Post>();

            var items = _connection.Query<Post>(query, new { CategoryId = categoryId });

            foreach (var item in items)
                posts.Add(item);

            return posts;
        }

        public List<Post> ListPostTags()
        {
            var query = @"SELECT
                            [Post].*,
                            [Tag].*
                        FROM
                            [Post]
                            LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                            LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var postAux = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (postAux == null)
                    {
                        postAux = post;
                        if (tag != null)
                            postAux.Tags.Add(tag);
                        posts.Add(postAux);
                    }
                    else
                        postAux.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }
    }
}