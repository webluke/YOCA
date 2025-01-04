CREATE PROCEDURE [dbo].[spProjectTasks_GetAll]

	

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
END
