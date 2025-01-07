CREATE PROCEDURE [dbo].[spPage_GetAll]


AS
BEGIN 

	SELECT 
		[Id],
		[Order],
		[Title],
		[Slug],
		[MenuName],
		[Icon],
		[Content],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount]
	FROM dbo.[Page]
	ORDER BY [Order], [MenuName] ASC

END
