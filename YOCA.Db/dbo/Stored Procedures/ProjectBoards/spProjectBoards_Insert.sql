CREATE PROCEDURE [dbo].[spProjectBoards_Insert]

	@Id NCHAR(10),
	@ProjectId NCHAR(10),
	@Order INT,
	@Title NVARCHAR(50),
	@Icon NVARCHAR(50), 
	@Color NVARCHAR(50),
	@BackgroundColor NVARCHAR(50)

AS
BEGIN

	INSERT INTO [dbo].[ProjectBoards]
	(
		[Id],
		[ProjectId],
		[Order],
		[Title],
		[Icon],
		[Color],
		[BackgroundColor]
	)
	VALUES
	(
		@Id,
		@ProjectId,
		@Order,
		@Title,
		@Icon,
		@Color,
		@BackgroundColor
	)

END