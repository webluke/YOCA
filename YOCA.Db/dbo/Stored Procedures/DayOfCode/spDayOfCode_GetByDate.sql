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
		[Tomorrow],
		[Summary],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount]
	FROM
		[dbo].[DayOfCode]
	WHERE
		[Date] = @Date;

END
