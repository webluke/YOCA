﻿CREATE PROCEDURE [dbo].[spClipboard_GetAllAdmin]
	


AS
BEGIN

	SELECT 
		[Id],
		[Order],
		[Status],
		[DateCompleted],
		[Title],
		[Note],
		[TimeCreated],
		[TimeUpdated]
	FROM dbo.[Clipboard]
	ORDER BY [Order] DESC, [Status] ASC

END