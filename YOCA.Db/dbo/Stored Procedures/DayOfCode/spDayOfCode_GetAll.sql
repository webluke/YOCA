CREATE PROCEDURE [dbo].[spDayOfCode_GetAll]

	

AS
BEGIN

	SELECT
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
	ORDER BY [Day] DESC;


END
