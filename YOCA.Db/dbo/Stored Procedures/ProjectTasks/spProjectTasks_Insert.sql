CREATE PROCEDURE [dbo].[spProjectTasks_Insert]

	@Id NCHAR(10),
	@ProjectId NCHAR(10),
	@Order INT,
	@Status INT,
	@Title NVARCHAR(50),
	@Description NVARCHAR(MAX)

AS
BEGIN

	INSERT INTO [dbo].[ProjectTasks]
	(
		[Id],
		[ProjectId],
		[Order],
		[Status],
		[Title],
		[Description]
	)
	VALUES
	(
		@Id,
		@ProjectId,
		@Order,
		@Status,
		@Title,
		@Description
	)

END
