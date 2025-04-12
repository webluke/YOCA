CREATE PROCEDURE [dbo].[spProjectTasks_GetAllByProjectId]

	@ProjectId NCHAR(10)

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
	WHERE [ProjectId] = @ProjectId
	AND [Status] < 299
	ORDER BY [Order] DESC, [Status] ASC;

END