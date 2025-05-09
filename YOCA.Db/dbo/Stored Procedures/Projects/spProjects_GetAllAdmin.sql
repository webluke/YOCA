﻿CREATE PROCEDURE [dbo].[spProjects_GetAllAdmin]

	

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
	ORDER BY [Order] DESC, [Status] ASC;

END