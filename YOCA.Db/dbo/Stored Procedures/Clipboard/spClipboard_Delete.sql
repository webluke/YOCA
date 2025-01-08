CREATE PROCEDURE [dbo].[spClipboard_Delete]

	@Id NCHAR(10)

AS
BEGIN

	DELETE FROM [dbo].[Clipboard]
	WHERE [Id] = @Id

END