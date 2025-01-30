CREATE PROCEDURE [dbo].[spRewind_GetByDate]

	@Date DATETIME

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
	WHERE [Date] = @Date AND IsPublished = 1

END