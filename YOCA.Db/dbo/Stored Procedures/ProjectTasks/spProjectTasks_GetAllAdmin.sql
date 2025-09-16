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
		[TimeUpdated],
		[Hidden]
	FROM
		[dbo].[ProjectTasks]
	ORDER BY [Order] DESC, [Status] ASC;
END
