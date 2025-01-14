CREATE PROCEDURE [dbo].[spClipboard_GetById]
	
	@Id NCHAR(10)

AS
BEGIN

	SELECT 
		[Id],
		[Order],
		[Status],
		[DateCompleted],
		[Title],
		[Note],
		[TimeCreated],
		[TimeUpdated]
	FROM dbo.[Clipboard]
	WHERE
		[Id] = @Id

END