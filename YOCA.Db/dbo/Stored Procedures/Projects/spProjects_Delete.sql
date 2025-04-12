CREATE PROCEDURE [dbo].[spProjects_Delete]
	
	@Id NCHAR(10)

AS
BEGIN

	DELETE FROM [dbo].[ProjectTasks]
	WHERE
		[ProjectId] = @Id;

	DELETE FROM [dbo].[ProjectBoards]
	WHERE
		[ProjectId] = @Id;

	DELETE FROM [dbo].[Projects]
	WHERE
		[Id] = @Id;

END