CREATE PROCEDURE [dbo].[spDayOfCode_GetByDate]

	@Date DATE

AS
BEGIN
	
	SELECT
		[Id],
		[Day],
		[Date],
		[Goal],
		[Result],
		[Summary],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount]
	FROM
		[dbo].[DayOfCode]
	WHERE
		[Date] = @Date

END
