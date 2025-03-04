CREATE PROCEDURE [dbo].[spIdeas_Update]
	
	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@Title NVARCHAR(50),
	@Content NVARCHAR(MAX)

AS
BEGIN

	UPDATE [dbo].[Ideas]
	SET
		[Order] = @Order,
		[Status] = @Status,
		[Title] = @Title,
		[Content] = @Content,
		[TimeUpdated] = SYSUTCDATETIME()
	WHERE
		[Id] = @Id;
END
