USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[Users_GetAll]    Script Date: 7/8/2022 9:30:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_GetAll]
AS BEGIN 
SELECT * FROM dbo.tUsers;
END
GO


