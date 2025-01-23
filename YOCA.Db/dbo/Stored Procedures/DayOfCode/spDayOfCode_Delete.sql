CREATE PROCEDURE [dbo].[spDayOfCode_Delete]

	@Id NCHAR(10)

AS
BEGIN 

	DELETE FROM [dbo].[DayOfCode]
	WHERE [Id] = @Id;

END
