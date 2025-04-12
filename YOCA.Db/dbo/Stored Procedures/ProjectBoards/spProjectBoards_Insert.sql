CREATE PROCEDURE [dbo].[spProjectBoards_Insert]

	@Id NCHAR(10),
	@ProjectId NCHAR(10),
	@Order INT,
	@Title NVARCHAR(50)

AS
BEGIN

	INSERT INTO [dbo].[ProjectBoards]
	(
		[Id],
		[ProjectId],
		[Order],
		[Title]
	)
	VALUES
	(
		@Id,
		@ProjectId,
		@Order,
		@Title
	)

END