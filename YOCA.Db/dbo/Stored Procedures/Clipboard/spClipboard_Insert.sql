CREATE PROCEDURE [dbo].[spClipboard_Insert]
	
	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@DateCompleted DATE,
	@Title NVARCHAR(50),
	@Note NVARCHAR(MAX)

AS
BEGIN

	INSERT INTO dbo.[Clipboard]
	(
		[Id],
		[Order],
		[Status],
		[DateCompleted],
		[Title],
		[Note]
	)
	VALUES
	(
		@Id,
		@Order,
		@Status,
		@DateCompleted,
		@Title,
		@Note
	)

END
