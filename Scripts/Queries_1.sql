SELECT * FROM [User]

SELECT * FROM [Role]

SELECT * FROM [UserRole]

SELECT * FROM [Tag]

SELECT * FROM [Category]

SELECT * FROM [Post]

SELECT * FROM [PostTag]

DELETE FROM [User] WHERE [Id] IN (2, 3, 4)

DELETE FROM [Tag] WHERE [Id] > 1

DELETE FROM [Post] WHERE [Id] > 1

DELETE FROM [UserRole] WHERE [UserId] = 3

DBCC CHECKIDENT ('User', RESEED, 3)

DBCC CHECKIDENT ('Tag', RESEED, 2)

DBCC CHECKIDENT ('Role', RESEED, 4)

DBCC CHECKIDENT ('Category', RESEED, 4)

DBCC CHECKIDENT ('Post', RESEED, 1)

DBCC CHECKIDENT ('UserRole', RESEED, 2)

SELECT
    [User].*,
    [Role].*
FROM
    [User]
    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]


SELECT
    [User].[Id],
    [User].[Name]
FROM
    [User]
    INNER JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
    INNER JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]
WHERE [Role].[Name] = 'Autor'


SELECT
    [Post].*,
    [Category].[Name] AS [Category],
    [User].[Name] AS [Author]
FROM 
    [Post]
    INNER JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
    INNER JOIN [User] ON [User].[Id] = [Post].[AuthorId]

SELECT
    [Category].[Name],
    COUNT([Post].[Id]) AS [NumberOfPost]
FROM [Category]
INNER JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]
GROUP BY [Category].[Name]

SELECT
    [Category].*,
    [Post].*
FROM
    [Category]
    INNER JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]