CREATE PROCEDURE [dbo].[spDayOfCode_GetById]
	
	@Id NCHAR(10)

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
		[Id] = @Id

END