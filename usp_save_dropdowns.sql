USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_save_dropdowns]    Script Date: 12/08/2015 11:50:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_save_dropdowns]
	@p_table_name VARCHAR(50),
	@p_id BIGINT = NULL OUTPUT,
	@p_description VARCHAR(50) = NULL
AS
BEGIN
/*

EXEC usp_save_dropdowns 'patron_type', NULL, Admin

*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	print '1111111111111111';
	print 'TBL: ' + @p_table_name;
	print 'ID: ' + CAST(@p_id as VARCHAR);
	print 'DSC: ' + @p_description;
	
	DECLARE @v_sql NVARCHAR(4000);
	DECLARE @v_parms NVARCHAR(4000);
	DECLARE @d_table_name VARCHAR(50);

	IF @p_id IS NULL OR @p_id <= 0
	BEGIN
		--  DO AN INSERT
		SELECT @v_sql = 'INSERT INTO ' + @p_table_name
		                + ' (description) '
		                + ' VALUES('''+ @p_description + ''')';
		print @v_sql;
		EXEC sp_executesql @v_sql;
	END
	ELSE
	BEGIN
		-- DO AN UPDATE
		print 'doing an update'

		SELECT @v_sql = 'UPDATE ' + @p_table_name
		                + ' SET description  = '''+ @p_description + ' ''    '
		                + ' WHERE id = '+ CAST(@p_id AS VARCHAR);
		print @v_sql;
		
		/*
		SELECT @v_sql = N' UPDATE @d_table_name SET description = @d_description WHERE id = @d_id';
		print @v_sql;
		SELECT @v_parms = N'@d_table_name  VARCHAR(50), @d_description  VARCHAR(50), @d_id  INT';
		print @v_parms;
		EXEC sp_executesql @v_sql, @v_parms, @p_table_name, @p_description, @p_id;
		*/
		
		EXEC sp_executesql @v_sql;
	END

END



GO

