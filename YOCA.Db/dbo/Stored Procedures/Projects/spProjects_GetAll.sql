CREATE PROCEDURE [dbo].[spProjects_GetAll]

	

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
	ORDER By 
		[Order] ASC

END