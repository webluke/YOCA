CREATE PROCEDURE [dbo].[spProjectBoards_GetById]

	@Id NCHAR(10)

AS
BEGIN 

	SELECT 
		[Id],
		[ProjectId],
		[Order],
		[Title],
		[Icon],
		[Color],
		[BackgroundColor]
	FROM 
		[dbo].[ProjectBoards]
	WHERE
		[Id] = @Id

END