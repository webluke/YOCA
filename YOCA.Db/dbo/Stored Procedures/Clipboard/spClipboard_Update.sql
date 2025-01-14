CREATE PROCEDURE [dbo].[spClipboard_Update]
	
	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@DateCompleted DATE,
	@Title NVARCHAR(50),
	@Note NVARCHAR(MAX)

AS
BEGIN

	UPDATE dbo.[Clipboard]
	SET
		[Order] = @Order,
		[Status] = @Status,
		[DateCompleted] = @DateCompleted,
		[Title] = @Title,
		[Note] = @Note,
		[TimeUpdated] = SYSUTCDATETIME()
	WHERE
		[Id] = @Id
END
