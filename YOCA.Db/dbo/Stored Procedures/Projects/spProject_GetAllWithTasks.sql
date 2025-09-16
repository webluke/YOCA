CREATE PROCEDURE [dbo].[spProject_GetAllWithTasks]
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

	SELECT 
		[Id],
		[ProjectId],
		[Order],
		[Title]
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
	WHERE [Hidden] = 0
	ORDER BY [Order] ASC;
END