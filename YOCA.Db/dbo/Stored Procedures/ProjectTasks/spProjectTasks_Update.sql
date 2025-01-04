CREATE PROCEDURE [dbo].[spProjectTasks_Update]
	
	@Id NCHAR(10),
	@ProjectId NCHAR(10),
	@Order INT,
	@Status INT,
	@Title NVARCHAR(50),
	@Description NVARCHAR(MAX)

AS
BEGIN

	UPDATE dbo.[ProjectTasks]
	SET 
		[ProjectId] = @ProjectId,
		[Order] = @Order,
		[Status] = @Status,
		[Title] = @Title,
		[Description] = @Description,
		[TimeUpdated] = SYSUTCDATETIME()

	WHERE Id = @Id

END
