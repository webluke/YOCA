CREATE PROCEDURE [dbo].[spLinks_Delete]

	@Id NCHAR(10)

AS
BEGIN
	
	DELETE FROM [dbo].[Links]
	WHERE [Id] = @Id

END