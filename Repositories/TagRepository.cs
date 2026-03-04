using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;
        public TagRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Tag> ListTagPosts()
        {
            var query = @"SELECT
                            [Tag].*,
                            [Post].*
                        FROM
                            [Tag]
                            LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

            var tags = new List<Tag>();

            var items = _connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var tagAux = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (tagAux == null)
                    {
                        tagAux = tag;
                        if (post != null)
                            tagAux.Posts.Add(post);
                        tags.Add(tagAux);
                    }
                    else
                        tagAux.Posts.Add(post);

                    return tag;
                }, splitOn: "Id");

            return tags;
        }
    }
}