CREATE PROCEDURE [dbo].[spPage_GetAllMenu]

	

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
	WHERE
		[IsPublished] = 1
	ORDER BY [Order], [MenuName] ASC
END
