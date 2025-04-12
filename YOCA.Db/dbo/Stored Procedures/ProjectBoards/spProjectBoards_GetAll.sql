CREATE PROCEDURE [dbo].[spProjectBoards_GetAll]

	

AS
BEGIN 

	SELECT 
		[Id],
		[ProjectId],
		[Order],
		[Title]
	FROM 
		[dbo].[ProjectBoards]
	ORDER BY [Order] ASC;

END