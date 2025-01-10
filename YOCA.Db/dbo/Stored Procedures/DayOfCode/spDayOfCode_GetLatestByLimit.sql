CREATE PROCEDURE [dbo].[spDayOfCode_GetLatestByLimit]

	@Limit INT

AS
BEGIN
	
	SELECT TOP (@Limit)
		[Id],
		[Day],
		[Date],
		[Goal],
		[Result],
		[Tomorrow],
		[Summary],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount]
	FROM
		[dbo].[DayOfCode]
	ORDER BY [Date] DESC

END
