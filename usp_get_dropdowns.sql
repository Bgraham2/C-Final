USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_dropdowns]    Script Date: 12/08/2015 11:47:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_dropdowns]
	@p_table_name VARCHAR(50)
	, @p_id BIGINT = NULL
AS
BEGIN
/*

EXEC usp_get_dropdowns 'patron_type'


*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @v_sql NVARCHAR(4000);

	IF @p_id IS NULL
	BEGIN
		SELECT @v_sql = 'SELECT id, description FROM ' + @p_table_name;
	END
	ELSE
	BEGIN
		SELECT @v_sql = 'SELECT id, description FROM ' + @p_table_name + ' WHERE id = ' + CAST(@p_id AS VARCHAR);
	END
	
	
	
	EXEC sp_executesql @v_sql;
	
END



GO

