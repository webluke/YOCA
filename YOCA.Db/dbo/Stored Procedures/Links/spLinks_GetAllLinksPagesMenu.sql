CREATE PROCEDURE [dbo].[spLinks_GetAllLinksPagesMenu]



AS
BEGIN

	SELECT 
		[Id],
		[Order],
		[Title],
		[URL],
		[MenuName],
		[Icon]
	FROM [dbo].[Links]
	WHERE [IsPublished] = 1

	UNION

	SELECT 
		[Id],
		[Order],
		[Title],
		[URL] = 'page/'+[Slug],
		[MenuName],
		[Icon]
	FROM [dbo].[Page]
	WHERE [IsPublished] = 1

	ORDER BY [Order], [MenuName] ASC

END
