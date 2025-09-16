CREATE PROCEDURE [dbo].[spProjectBoards_Init]
    @ProjectId NVARCHAR(10),
    @BoardIdNew NVARCHAR(10),
    @BoardIdInProgress NVARCHAR(10),
    @BoardIdDone NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.ProjectBoards (Id, ProjectId, [Order], Title)
    VALUES 
        (@BoardIdNew, @ProjectId, 1, 'New'),
        (@BoardIdInProgress, @ProjectId, 2, 'In-Progress'),
        (@BoardIdDone, @ProjectId, 3, 'Done');
END