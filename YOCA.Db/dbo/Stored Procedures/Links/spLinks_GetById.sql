CREATE PROCEDURE [dbo].[spLinks_GetById]

	@Id NCHAR(10)

AS
BEGIN

	SELECT
		[Id],
		[Order],
		[Type],
		[Title],
		[URL],
		[MenuName],
		[Icon],
		[TimeCreated],
		[TimeUpdated],
		[IsPublished]
	FROM [dbo].[Links]
	WHERE [Id] = @Id

END
