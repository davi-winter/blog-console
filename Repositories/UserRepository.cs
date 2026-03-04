using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public void CreateUserRole(int userId, int roleId)
        {
            var sql = "INSERT INTO [UserRole] ([UserId], [RoleId]) VALUES (@UserId, @RoleId)";

            _connection.Execute(sql, new { UserId = userId, RoleId = roleId });
        }

        public void DeleteUserRole(int userId, int roleId)
        {
            var sql = "DELETE FROM [UserRole] WHERE [UserId] = @UserId AND [RoleId] = @RoleId";

            _connection.Execute(sql, new { UserId = userId, RoleId = roleId });
        }

        public List<User> ListUserAuthors()
        {
            var query = @"SELECT
                            [User].[Id],
                            [User].[Name]
                        FROM
                            [User]
                            INNER JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                            INNER JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]
                        WHERE [Role].[Name] = 'Autor'";

            var authors = new List<User>();

            var items = _connection.Query<User>(query);

            foreach (var item in items)
                authors.Add(item);

            return authors;
        }

        public List<User> ListUserRoles()
        {
            var query = @"SELECT
                            [User].*,
                            [Role].*
                        FROM
                            [User]
                            LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                            LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }
    }
}