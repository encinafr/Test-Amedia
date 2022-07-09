USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[Users_GetById]    Script Date: 7/8/2022 9:31:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_GetById]
@id int
AS BEGIN 
SELECT * FROM dbo.tUsers WHERE cod_usuario = @id;
END
GO


