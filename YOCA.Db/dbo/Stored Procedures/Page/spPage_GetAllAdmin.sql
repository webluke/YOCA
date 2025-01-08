CREATE PROCEDURE [dbo].[spPage_GetAllAdmin]

	

AS
BEGIN 
	SELECT 
		[Id],
		[Order],
		[Title],
		[Slug],
		[MenuName],
		[Icon],
		[ViewCount],
		[IsPublished]
	FROM dbo.[Page]
	ORDER BY [Order], [MenuName] ASC
END