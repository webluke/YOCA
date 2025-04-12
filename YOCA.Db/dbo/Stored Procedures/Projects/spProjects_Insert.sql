CREATE PROCEDURE [dbo].[spProjects_Insert]

	@Id NCHAR(10),
	@Order INT,
	@Status INT,
	@StartDate DATE,
	@EndDate DATE,
	@Title NVARCHAR(50),
	@Description NVARCHAR(MAX)

AS
BEGIN

	INSERT INTO [dbo].[Projects]
	(
		[Id],
		[Order],
		[Status],
		[StartDate],
		[EndDate],
		[Title],
		[Description]
	)
	VALUES
	(
		@Id,
		@Order,
		@Status,
		@StartDate,
		@EndDate,
		@Title,
		@Description
	);

END