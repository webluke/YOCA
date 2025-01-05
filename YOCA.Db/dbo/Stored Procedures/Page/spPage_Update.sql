CREATE PROCEDURE [dbo].[spPage_Update]
	
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
	UPDATE [dbo].[Page]
	SET
		[Order] = @Order,
		[Title] = @Title,
		[Slug] = @Slug,
		[MenuName] = @MenuName,
		[Icon] = @Icon,
		[Content] = @Content,
		[TimeUpdated] = SYSUTCDATETIME(),
		[IsPublished] = @IsPublished
	WHERE
		[Id] = @Id
END