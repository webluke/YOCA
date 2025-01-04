CREATE PROCEDURE [dbo].[spProjects_GetById]

	@Id NCHAR(10)

AS
BEGIN 

	SELECT 
		[Id],
		[Order],
		[Status],
		[StartDate],
		[EndDate],
		[Title],
		[Description],
		[TimeCreated],
		[TimeUpdated],
		[ViewCount]
	FROM 
		[dbo].[Projects]
	WHERE
		[Id] = @Id

END