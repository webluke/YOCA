CREATE PROCEDURE [dbo].[spProjectTasks_GetAll]

	

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
	WHERE [Hidden] = 0
	ORDER BY [Order] DESC, [Status] ASC;
END
