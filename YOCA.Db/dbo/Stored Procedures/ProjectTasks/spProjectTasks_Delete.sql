CREATE PROCEDURE [dbo].[spProjectTasks_Delete]

	@Id NCHAR(10)

AS
BEGIN 

	DELETE FROM [dbo].[ProjectTasks]
	WHERE
		[Id] = @Id

END
