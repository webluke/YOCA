IF NOT EXISTS (SELECT 1 from dbo.[DayOfCode])
BEGIN

	DECLARE  @baseId NCHAR(10) = '0000000000';

	INSERT INTO dbo.[DayOfCode] ([Id], [Day], [Date], [Goal], [Result], [Summary], [ViewCount])
	VALUES(@baseId, -1, '2024-12-31', 'Test Goal', 'Test Result', 'This is only a test Summary', 33);

END
