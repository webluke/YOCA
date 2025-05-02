CREATE PROCEDURE [dbo].[spRewind_GetAllAdmin]



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
	ORDER BY Date DESC;

END