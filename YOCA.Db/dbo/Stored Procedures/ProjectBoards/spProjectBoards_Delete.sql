CREATE PROCEDURE [dbo].[spProjectBoards_Delete]
	
	@Id NCHAR(10)

AS
BEGIN

	DELETE FROM [dbo].[ProjectBoards]
	WHERE
		[Id] = @Id

END