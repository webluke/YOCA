CREATE PROCEDURE [dbo].[spDayOfCode_GetDateRange]

	@Start DATE,
	@End DATE

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
		[Date] BETWEEN @Start AND @End
	ORDER BY 
		[Date] DESC

END
