CREATE PROCEDURE [dbo].[spDayOfCode_Update]

	@Id NCHAR(10),
	@Day INT,
	@Date DATE,
	@Goal NVARCHAR(150),
	@Result NVARCHAR(150),
	@Tomorrow NVARCHAR(150),
	@Summary NVARCHAR(MAX)

AS
BEGIN

	UPDATE [dbo].[DayOfCode]
	SET
		[Day] = @Day,
		[Date] = @Date,
		[Goal] = @Goal,
		[Result] = @Result,
		[Tomorrow] = @Tomorrow,
		[Summary] = @Summary,
		[TimeUpdated] = SYSUTCDATETIME()
	WHERE
		[Id] = @Id

END
