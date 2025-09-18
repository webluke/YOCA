CREATE PROCEDURE [dbo].[spProjectBoards_Init]

    @ProjectId NVARCHAR(10),
    @BoardIdNew NVARCHAR(10),
    @BoardIdInProgress NVARCHAR(10),
    @BoardIdDone NVARCHAR(10)

AS
BEGIN

    INSERT INTO dbo.ProjectBoards (Id, ProjectId, [Order], [Title], [Color], [BackgroundColor], [Icon])
    VALUES 
        (@BoardIdNew, @ProjectId, 1, 'New', '#ffffff', '#71717B', 'fas fa-lightbulb'),
        (@BoardIdInProgress, @ProjectId, 2, 'In-Progress', '#ffffff', '#009dff', 'fas fas fa-hammer'),
        (@BoardIdDone, @ProjectId, 3, 'Done', '#ffffff', '#2AA63E', 'fas fa-flag-checkered');

END