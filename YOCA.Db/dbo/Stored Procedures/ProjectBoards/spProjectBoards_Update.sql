CREATE PROCEDURE [dbo].[spProjectBoards_Update]

	@Id NCHAR(10),
	@Order INT,
	@Title NVARCHAR(50)

AS
BEGIN

	UPDATE [dbo].[ProjectBoards]
	SET
		[Order] = @Order,
		[Title] = @Title
	WHERE
		[Id] = @Id

END
