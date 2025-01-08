CREATE PROCEDURE [dbo].[spClipboard_Update]
	
	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@Title NVARCHAR(50),
	@Note NVARCHAR(MAX)

AS
BEGIN

	UPDATE dbo.[Clipboard]
	SET
		[Order] = @Order,
		[Status] = @Status,
		[Title] = @Title,
		[Note] = @Note,
		[TimeUpdated] = SYSUTCDATETIME()
	WHERE
		[Id] = @Id
END
