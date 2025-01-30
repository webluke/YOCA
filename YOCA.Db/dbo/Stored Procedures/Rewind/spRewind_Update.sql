CREATE PROCEDURE [dbo].[spRewind_Update]

	@Id NCHAR(10),
	@Date DATE,
	@Year INT,
	@Month INT,
	@Title NVARCHAR(150),
	@Slug NVARCHAR(150),
	@Content NVARCHAR(MAX),
	@IsPublished BIT

AS
BEGIN
	
	UPDATE [dbo].[Rewind]
	SET
		[Date] = @Date,
		[Year] = @Year,
		[Month] = @Month,
		[Title] = @Title,
		[Slug] = @Slug,
		[Content] = @Content,
		[TimeUpdated] = SYSUTCDATETIME(),
		[IsPublished] = @IsPublished
	WHERE
		[Id] = @Id;

END