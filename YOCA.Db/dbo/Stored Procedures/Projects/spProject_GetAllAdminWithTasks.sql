CREATE PROCEDURE [dbo].[spProject_GetAllAdminWithTasks]
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

	SELECT
		[Id],
		[ProjectId],
		[BoardId],
		[Order],
		[Status],
		[Title],
		[Description],
		[TimeCreated],
		[TimeUpdated],
		[Hidden]
	FROM
		[dbo].[ProjectTasks]
	ORDER BY [Order] ASC;
END