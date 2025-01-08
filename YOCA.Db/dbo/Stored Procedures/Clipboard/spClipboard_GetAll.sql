CREATE PROCEDURE [dbo].[spClipboard_GetAll]
	


AS
BEGIN

	SELECT 
		[Id],
		[Order],
		[Status],
		[Title],
		[Note],
		[TimeCreated],
		[TimeUpdated]
	FROM dbo.[Clipboard]
	WHERE NOT [Status] > 299
	ORDER BY [Order] DESC, [Status] ASC

END

