CREATE PROCEDURE [dbo].[spProjectBoards_GetAllAdmin]

	

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
	ORDER BY [Order] ASC;

END