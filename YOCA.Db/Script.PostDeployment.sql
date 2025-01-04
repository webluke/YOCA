IF NOT EXISTS (SELECT 1 from dbo.[DayOfCode])
BEGIN

	DECLARE  @baseId NCHAR(10) = '0000000000';

	INSERT INTO dbo.[DayOfCode] ([Id], [Day], [Date], [Goal], [Result], [Summary], [ViewCount])
	VALUES(@baseId, -1, '2024-12-31', 'Test Goal', 'Test Result', 'This is only a test Summary', 33);

	INSERT INTO dbo.[Projects] ([Id], [Order], [StartDate], [EndDate], [Title], [Description])
	VALUES (@baseId, -1, '2024-12-31', '2024-12-31', 'Test Project', 'This is only a test Project');

	INSERT INTO dbo.[ProjectTasks] ([Id], [ProjectId], [Order], [Title], [Description])
	VALUES (@baseId, @baseId, 0, 'Test Task 0', 'This is only a test Task 0'),
			(@baseId, @baseId, 10, 'Test Task 1', 'This is only a test Task 1'),
			(@baseId, @baseId, 20, 'Test Task 2', 'This is only a test Task 2');

END
