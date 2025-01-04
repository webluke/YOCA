CREATE PROCEDURE [dbo].[spProjectTasks_GetAllByProjectId]

	@ProjectId NCHAR(10)

AS
BEGIN

	SELECT
		[Id],
		[ProjectId],
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
	ORDER BY
		[Order]

END