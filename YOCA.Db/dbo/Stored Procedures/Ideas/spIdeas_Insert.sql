CREATE PROCEDURE [dbo].[spIdeas_Insert]
	
	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@Title NVARCHAR(50),
	@Content NVARCHAR(MAX)

AS
BEGIN

	INSERT INTO [dbo].[Ideas]
	(
		[Id],
		[Order],
		[Status],
		[Title],
		[Content]
	)
	VALUES
	(
		@Id,
		@Order,
		@Status,
		@Title,
		@Content
	);

END
