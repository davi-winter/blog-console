INSERT INTO [User]
VALUES ('Fulano da Silva', 'fulano@gmail.com', '1234567', 'Equipe do fulano', 'http://', 'fulano-da-silva')

INSERT INTO [User]
VALUES ('Jose dos Santos', 'jose@gmail.com', '987654312', 'Equipe do jose', 'http://', 'jose-dos-santos')

INSERT INTO [User]
VALUES ('Maria Nogueira', 'marianogueira@gmail.com', '84865412', 'Equipe da maria', 'http://', 'maria-nogueira')

INSERT INTO [Post]
VALUES (4, 2, 'Novidades no .NET 11', 'Resumo do post', 'Texto detalhando o post', 'novidades-dotnet-11', '2026-02-20', GETDATE())

INSERT INTO [Role] VALUES ('Autor', 'author')

INSERT INTO [UserRole] VALUES (2, 4)

INSERT INTO [PostTag] VALUES (2, 1)

INSERT INTO [Tag] VALUES ('ASP.NET', 'aspnet')

UPDATE [post] SET
    [Post].[CategoryId] = 4
WHERE [Post].[Id] = 2

