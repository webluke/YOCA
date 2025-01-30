CREATE PROCEDURE [dbo].[spRewind_GetBySlug]

	@Slug NVARCHAR(150)

AS
BEGIN

	SELECT 
		[Id],
		[Date],
		[Year],
		[Month],
		[Title],
		[Slug],
		[Content],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount],
		[IsPublished]
	FROM Rewind
	WHERE [Slug] = @Slug AND IsPublished = 1

END