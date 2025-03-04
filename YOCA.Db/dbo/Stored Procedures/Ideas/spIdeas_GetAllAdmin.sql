CREATE PROCEDURE [dbo].[spIdeas_GetAllAdmin]
	


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
	ORDER BY [Order] DESC, [Status] ASC;

END