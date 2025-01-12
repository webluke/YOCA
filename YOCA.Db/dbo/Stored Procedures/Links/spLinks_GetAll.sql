CREATE PROCEDURE [dbo].[spLinks_GetAll]



AS
BEGIN
	
	SELECT 
		[Id],
		[Order],
		[Type],
		[Title],
		[URL],
		[MenuName],
		[Icon],
		[TimeCreated],
		[TimeUpdated],
		[IsPublished]
	FROM [dbo].[Links]
	WHERE [IsPublished] = 1
	ORDER BY [Order], [MenuName] ASC

END
