CREATE PROCEDURE [dbo].[spProjectBoards_Update]

	@Id NCHAR(10),
	@ProjectId NCHAR(10),
	@Order INT,
	@Title NVARCHAR(50),
	@Icon NVARCHAR(50), 
	@Color NVARCHAR(50),
	@BackgroundColor NVARCHAR(50)

AS
BEGIN

	UPDATE [dbo].[ProjectBoards]
	SET
		[ProjectId] = @ProjectId,
		[Order] = @Order,
		[Title] = @Title,
		[Icon] = @Icon,
		[Color] = @Color,
		[BackgroundColor] = @BackgroundColor 
	WHERE
		[Id] = @Id

END
