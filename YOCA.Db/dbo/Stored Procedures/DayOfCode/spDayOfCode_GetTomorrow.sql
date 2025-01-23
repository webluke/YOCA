CREATE PROCEDURE [dbo].[spDayOfCode_GetTomorrow]

	

AS
BEGIN

	SELECT TOP 1
		[Id],
		[Day],
		[Date],
		[Tomorrow]
	FROM
		[dbo].[DayOfCode]
	ORDER BY [Day] DESC;

END