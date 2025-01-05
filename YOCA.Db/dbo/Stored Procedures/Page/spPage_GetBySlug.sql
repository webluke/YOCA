CREATE PROCEDURE [dbo].[spPage_GetBySlug]

	@Slug NVARCHAR(150)

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
		[ViewCount],
		[IsPublished]
	FROM dbo.[Page]
	WHERE
		[IsPublished] = 1 AND
		[Slug] = @Slug
END