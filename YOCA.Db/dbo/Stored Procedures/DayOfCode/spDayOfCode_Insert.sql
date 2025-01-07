CREATE PROCEDURE [dbo].[spDayOfCode_Insert]
	@Id NCHAR(10),
	@Day INT,
	@Date DATE,
	@Goal NVARCHAR(150),
	@Result NVARCHAR(150),
	@Summary NVARCHAR(MAX)

AS 
BEGIN
	INSERT INTO [dbo].[DayOfCode] ([Id], [Day], [Date], [Goal], [Result], [Summary])
	VALUES (@Id, @Day, @Date, @Goal, @Result, @Summary)
END
