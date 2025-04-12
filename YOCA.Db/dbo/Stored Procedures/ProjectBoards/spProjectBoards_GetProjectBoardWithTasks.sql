CREATE PROCEDURE [dbo].[spProjectBoards_GetProjectBoardWithTasks]
	
	@ProjectId NCHAR(10)

AS
BEGIN

	SELECT b.*, t.*
            FROM [dbo].[ProjectBoards] b
            LEFT JOIN [dbo].[ProjectTasks] t ON b.Id = t.BoardId
            WHERE b.ProjectId = @ProjectId
            ORDER BY b.[Order], t.[Order];

END
