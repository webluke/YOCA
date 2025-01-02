CREATE PROCEDURE [dbo].[spDayOfCode_GetByPageNumber]

	@PageNumber INT,
	@PageSize INT

AS
BEGIN

	SELECT 
		[Id], 
		[Day], 
		[Date], 
		[Goal], 
		[Result], 
		[Summary], 
		[TimeCreated], 
		[TimeUpdated], 
		[ViewCount]
	FROM 
		[dbo].[DayOfCode]
	ORDER BY 
		[Date] ASC
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

END
