CREATE PROCEDURE [dbo].[spProjectBoards_GetAllByProjectId]

	@ProjectId NCHAR(10)

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
		[ProjectId] = @ProjectId
	Order BY [Order] ASC;

END