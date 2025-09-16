CREATE PROCEDURE [dbo].[spProject_GetAllAdminWithTasks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.Projects
    ORDER BY [Order];

    SELECT *
    FROM dbo.ProjectBoards
    ORDER BY [Order];

    SELECT *
    FROM dbo.ProjectTasks
    ORDER BY [Order];
END