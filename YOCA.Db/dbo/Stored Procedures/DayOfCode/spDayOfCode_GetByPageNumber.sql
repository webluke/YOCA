CREATE PROCEDURE [dbo].[spDayOfCode_GetByPageNumber]

	@PageNumber INT = 1,
	@PageSize INT = 30

AS
BEGIN

	SELECT 
		[Id], 
		[Day], 
		[Date], 
		[Goal], 
		[Result], 
		[Summary], 
		[Tomorrow],
		[TimeCreated], 
		[TimeUpdated], 
		[ViewCount]
	FROM 
		[dbo].[DayOfCode]
	ORDER BY 
		[Date] DESC
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;

	SELECT COUNT(*) AS TotalCount
	FROM [dbo].[DayOfCode];

END
