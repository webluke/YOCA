CREATE PROCEDURE [dbo].[spRewind_GetByIdAdmin]

	@Id NCHAR(10)

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
	WHERE [Id] = @Id;

END