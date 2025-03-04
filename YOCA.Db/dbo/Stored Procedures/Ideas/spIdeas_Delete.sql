CREATE PROCEDURE [dbo].[spIdeas_Delete]

	@Id NCHAR(10)

AS
BEGIN

	DELETE FROM [dbo].[Ideas]
	WHERE [Id] = @Id;

END