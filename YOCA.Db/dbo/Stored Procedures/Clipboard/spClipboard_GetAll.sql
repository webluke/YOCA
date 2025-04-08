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
   WHERE ([Status] < 299 AND [Status] != 100)  
      OR ([Status] = 100 AND [DateCompleted] >= DATEADD(DAY, -14, GETDATE()))
   ORDER BY [Order] DESC, [Status] ASC;

END

