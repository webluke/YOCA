CREATE PROCEDURE [dbo].[spPage_UpdatePublished]

	@Id NCHAR(10),
	@IsPublished BIT

AS
BEGIN
	UPDATE [dbo].[Page]
	SET
		[IsPublished] = @IsPublished
	WHERE
		[Id] = @Id
END