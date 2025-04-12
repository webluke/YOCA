CREATE PROCEDURE [dbo].[spProjectTasks_GetAllAdmin]

	

AS
BEGIN

	SELECT
		[Id],
		[ProjectId],
		[BoardId],
		[Order],
		[Status],
		[Title],
		[Description],
		[TimeCreated],
		[TimeUpdated]
	FROM
		[dbo].[ProjectTasks]
	WHERE [Status] < 299
	ORDER BY [Order] DESC, [Status] ASC;
END
