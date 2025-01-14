CREATE PROCEDURE [dbo].[spClipboard_GetAll]
	


AS
BEGIN

   SELECT  
	   [Id],  
	   [Order],  
	   [Status],  
	   [DateCompleted],  
	   [Title],  
	   [Note],  
	   [TimeCreated],  
	   [TimeUpdated]  
   FROM dbo.[Clipboard]  
   WHERE [Status] > 299  
   OR ([Status] = 100 AND [DateCompleted] >= DATEADD(DAY, -14, GETDATE()))
   OR ([Status] != 100 )
   ORDER BY [Order] DESC, [Status] ASC

END

