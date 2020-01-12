SELECT [u].[Id], [u].[CreatedDate], [u].[Name], [u].[UserId], [c].[Id], [c].[Completed], [c].[Name], [c].[UserChecklistId], [c0].[Id], [c0].[Name], [c0].[Path], [c0].[UserChecklistId]
FROM [UserChecklists] AS [u]
LEFT JOIN [Users] AS [u0] ON [u].[UserId] = [u0].[Id]
LEFT JOIN [ChecklistFields] AS [c] ON [u].[Id] = [c].[UserChecklistId]
LEFT JOIN [ChecklistImages] AS [c0] ON [u].[Id] = [c0].[UserChecklistId]
WHERE [u0].[Id] = @__userId_0
ORDER BY [u].[Id], [c].[Id], [c0].[Id]