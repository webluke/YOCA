CREATE PROCEDURE [dbo].[spRewind_GetByYearMonth]

	@Year INT,
	@Month INT

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
	WHERE [Year] = @Year AND [Month] = @Month AND IsPublished = 1;

END