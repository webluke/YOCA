CREATE PROCEDURE [dbo].[spProjects_Update]

	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@StartDate DATE,
	@EndDate DATE,
	@Title NVARCHAR(50),
	@Description NVARCHAR(MAX)

AS
BEGIN

	UPDATE [dbo].[Projects]
	SET
		[Order] = @Order,
		[Status] = @Status,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[Title] = @Title,
		[Description] = @Description,
		[TimeUpdated] = SYSUTCDATETIME()
	WHERE
		[Id] = @Id

END
