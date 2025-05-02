CREATE PROCEDURE [dbo].[spRewind_GetAllPreview]
AS
BEGIN

	SELECT 
		[Id],
		[Date],
		[Year],
		[Month],
		[Title],
		[Slug],
		LEFT([Content], 300) AS [Content],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount],
		[IsPublished]
	FROM Rewind
	WHERE IsPublished = 1
	ORDER BY Date DESC;

END