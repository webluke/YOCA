CREATE PROCEDURE [dbo].[spDayOfCode_GetByDay]

	@Day INT

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
	WHERE
		[Day] = @Day

END
