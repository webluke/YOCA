CREATE PROCEDURE [dbo].[spRewind_Insert]

	@Id NCHAR(10),
	@Date DATE,
	@Year INT,
	@Month INT,
	@Title NVARCHAR(150),
	@Slug NVARCHAR(150),
	@Content NVARCHAR(MAX),
	@IsPublished BIT

AS
BEGIN
	
	INSERT INTO [dbo].[Rewind] (
		[Id], 
		[Date], 
		[Year], 
		[Month], 
		[Title], 
		[Slug], 
		[Content], 
		[IsPublished]
	) VALUES ( 
		@Id, 
		@Date, 
		@Year, 
		@Month, 
		@Title, 
		@Slug, 
		@Content,
		@IsPublished
	);

END