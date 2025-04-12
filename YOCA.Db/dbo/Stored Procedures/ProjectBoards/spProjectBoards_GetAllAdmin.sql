CREATE PROCEDURE [dbo].[spProjectBoards_GetAllAdmin]

	

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