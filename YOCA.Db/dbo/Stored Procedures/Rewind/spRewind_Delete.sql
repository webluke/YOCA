CREATE PROCEDURE [dbo].[spRewind_Delete]

	@Id NCHAR(10)

AS
BEGIN

	DELETE FROM [dbo].[Rewind]
	WHERE [Id] = @Id;

END