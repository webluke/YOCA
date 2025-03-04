CREATE PROCEDURE [dbo].[spIdeas_GetById]
	
	@Id NCHAR(10)

AS
BEGIN

	SELECT 
		[Id],
		[Order],
		[Status],
		[Title],
		[Content],
		[TimeCreated],
		[TimeUpdated]
	FROM [dbo].[Ideas]
	WHERE
		[Id] = @Id;

END