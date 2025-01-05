CREATE PROCEDURE [dbo].[spPage_Insert]

	@Id NCHAR(10),
	@Order INT,
	@Title NVARCHAR(150),
	@Slug NVARCHAR(150),
	@MenuName NVARCHAR(50),
	@Icon NVARCHAR(100),
	@Content NVARCHAR(MAX),
	@IsPublished BIT

AS
BEGIN
	INSERT INTO [dbo].[Page]
	(
		[Id],
		[Order],
		[Title],
		[Slug],
		[MenuName],
		[Icon],
		[Content],
		[IsPublished]
	)
	VALUES
	(
		@Id,
		@Order,
		@Title,
		@Slug,
		@MenuName,
		@Icon,
		@Content,
		@IsPublished
	)
END