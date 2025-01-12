CREATE PROCEDURE [dbo].[spLinks_GetAllAdmin]



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
	ORDER BY [MenuName] ASC

END