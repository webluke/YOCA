CREATE PROCEDURE [dbo].[spLinks_Update]
	
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

	UPDATE [dbo].[Links]
	SET
		[Order] = @Order,
		[Type] = @Type,
		[Title] = @Title,
		[URL] = @URL,
		[MenuName] = @MenuName,
		[Icon] = @Icon,
		[TimeUpdated] = SYSUTCDATETIME(),
		[IsPublished] = @IsPublished
	WHERE [Id] = @Id

END
