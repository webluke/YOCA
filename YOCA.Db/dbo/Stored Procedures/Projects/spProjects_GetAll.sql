﻿CREATE PROCEDURE [dbo].[spProjects_GetAll]

	

AS
BEGIN 

	SELECT 
		[Id],
		[Order],
		[Status],
		[StartDate],
		[EndDate],
		[Title],
		[Description],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount]
	FROM 
		[dbo].[Projects]
	WHERE [Status] < 299 
	ORDER BY [Order] DESC, [Status] ASC;

END