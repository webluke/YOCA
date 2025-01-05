CREATE PROCEDURE [dbo].[spPage_Delete]
	
	@Id NCHAR(10)

AS
BEGIN

	DELETE FROM [dbo].[Page]
	WHERE
		[Id] = @Id

END