SELECT TOP(1) [u].[Id], [u].[AddressId], [u].[CreatedDate], [u].[Email], [u].[FirstName], [u].[LastName], [u].[Password], [u].[PasswordSalt]
FROM [Users] AS [u]
WHERE [u].[Email] = '@__email_0'