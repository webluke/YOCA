CREATE PROCEDURE [dbo].[spLinks_GetAllLinksPagesMenu]



AS
BEGIN

	SELECT 
		[Id],
		[Order],
		[Type],
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
		[Type] = 0,
		[Title],
		[URL] = 'page/'+[Slug],
		[MenuName],
		[Icon]
	FROM [dbo].[Page]
	WHERE [IsPublished] = 1

	ORDER BY [Order], [MenuName] ASC

END
