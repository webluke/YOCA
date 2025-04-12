CREATE PROCEDURE [dbo].[spProjectBoards_GetById]

	@Id NCHAR(10)

AS
BEGIN 

	SELECT 
		[Id],
		[ProjectId],
		[Order],
		[Title]
	FROM 
		[dbo].[ProjectBoards]
	WHERE
		[Id] = @Id

END