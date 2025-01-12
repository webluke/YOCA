CREATE PROCEDURE [dbo].[spLinks_Insert]

	@Id NCHAR(10),
	@Order INT,
	@Type INT,
	@Title NVARCHAR(150),
	@URL NVARCHAR(200),
	@MenuName NVARCHAR(50),
	@Icon NVARCHAR(100),
	@IsPublished BIT

AS
BEGIN

	INSERT INTO [dbo].[Links]
	(
		[Id],
		[Order],
		[Type],
		[Title],
		[URL],
		[MenuName],
		[Icon],
		[IsPublished]
	)
	VALUES
	(
		@Id,
		@Order,
		@Type,
		@Title,
		@URL,
		@MenuName,
		@Icon,
		@IsPublished
	)

END