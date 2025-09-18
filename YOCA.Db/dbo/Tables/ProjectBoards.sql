CREATE TABLE [dbo].[ProjectBoards]
(
	[Id] NCHAR(10) NOT NULL PRIMARY KEY UNIQUE, 
	[ProjectId] NCHAR(10) NOT NULL,
	[Order] INT NOT NULL DEFAULT 0,
	[Title] NVARCHAR(50) NOT NULL,
	[Icon] NVARCHAR(50) NULL DEFAULT 'fas fa-clipboard-list',
	[Color] NVARCHAR(50) NULL DEFAULT 'White',
	[BackgroundColor] NVARCHAR(50) NULL DEFAULT 'DodgerBlue'
)
