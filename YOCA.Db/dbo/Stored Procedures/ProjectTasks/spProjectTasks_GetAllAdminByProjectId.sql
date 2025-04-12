CREATE PROCEDURE [dbo].[spProjectTasks_GetAllAdminByProjectId]

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
	WHERE
		[ProjectId] = @ProjectId
	ORDER BY [Order] DESC, [Status] ASC

END