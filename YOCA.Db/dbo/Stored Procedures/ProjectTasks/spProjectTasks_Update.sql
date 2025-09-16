CREATE PROCEDURE [dbo].[spProjectTasks_Update]
	
	@Id NCHAR(10),
	@ProjectId NCHAR(10),
	@BoardId NCHAR(10),
	@Order INT,
	@Status INT,
	@Title NVARCHAR(50),
	@Description NVARCHAR(MAX),
	@Hidden BIT

AS
BEGIN

	UPDATE dbo.[ProjectTasks]
	SET 
		[ProjectId] = @ProjectId,
		[BoardId] = @BoardId,
		[Order] = @Order,
		[Status] = @Status,
		[Title] = @Title,
		[Description] = @Description,
		[TimeUpdated] = SYSUTCDATETIME(),
		[Hidden] = @Hidden

	WHERE Id = @Id

END
