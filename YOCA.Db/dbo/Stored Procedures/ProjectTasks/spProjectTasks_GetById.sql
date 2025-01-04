CREATE PROCEDURE [dbo].[spProjectTasks_GetById]
	
	@Id NCHAR(10)

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
		[Id] = @Id

END