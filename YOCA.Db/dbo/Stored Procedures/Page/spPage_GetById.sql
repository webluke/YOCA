CREATE PROCEDURE [dbo].[spPage_GetById]

	@Id NCHAR(10)

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
		[Id] = @Id
END