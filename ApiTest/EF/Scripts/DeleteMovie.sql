USE [Test]
GO



CREATE PROCEDURE [dbo].[DeleteMovie]
		@txt_desc varchar(500)
AS
BEGIN


	BEGIN

	UPDATE [dbo].[tPelicula]
    SET [cant_disponibles_alquiler] = 0, [cant_disponibles_venta] = 0
	WHERE txt_desc = @txt_desc;

	END


	
END
GO


--Exec [dbo].[DeleteMovie] 'Mentiroso mentiroso';
