USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 7/8/2022 9:30:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

--Crear usuarios, cuyo documento no exista actualmente en la base de datos, en
--caso de existir, debería devolver un mensaje de error, en caso contrario insertarlo
CREATE PROCEDURE [dbo].[UpdateUser]
		@id varchar(50),
		@txt_user varchar(50),
		@txt_password varchar(50),
		@txt_nombre varchar(200),
		@txt_apellido varchar(200),
		@nro_doc varchar(50),
		@cod_rol int,
		@sn_activo int
AS
BEGIN

	IF EXISTS ( SELECT * FROM tUsers
                   WHERE nro_doc = @nro_doc )
	BEGIN
	UPDATE [dbo].[tUsers]
    SET [txt_user] = @txt_user
      ,[txt_password] = @txt_password
      ,[txt_nombre] = @txt_nombre
      ,[txt_apellido] = @txt_apellido
      ,[nro_doc] = @nro_doc
      ,[cod_rol] = @cod_rol
      ,[sn_activo] = @sn_activo
	WHERE cod_usuario = @id
	END
	
END
GO


