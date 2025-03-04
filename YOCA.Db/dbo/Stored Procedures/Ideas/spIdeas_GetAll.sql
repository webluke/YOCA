CREATE PROCEDURE [dbo].[spIdeas_GetAll]
	


AS
BEGIN

   SELECT  
	   [Id],  
	   [Order],  
	   [Status],  
	   [Title],  
	   [Content],  
	   [TimeCreated],  
	   [TimeUpdated]  
   FROM [dbo].[Ideas]
   WHERE [Status] < 299  
   ORDER BY [Order] DESC, [Status] ASC;

END

