USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_save_checked_out_item]    Script Date: 12/08/2015 11:49:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_save_checked_out_item]

@p_id					bigint = NULL OUTPUT,
@p_library_item_id		bigint = NULL OUTPUT,
@p_patron_id			bigint = NULL OUTPUT,
 @p_debug				int = NULL

AS
BEGIN
/*

DECLARE @v_id BIGINT

SET @v_id = NULL
exec usp_save_checked_out_item @v_id OUTPUT, 1, 1



*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @p_debug = 1
	BEGIN
		PRINT 'THIS IS A DEBUG LINE...'
		PRINT '@p_id = ' + CAST(@p_id AS VARCHAR)
		PRINT '@p_library_item_id = ' + CAST(@p_library_item_id AS VARCHAR)
		PRINT '@p_patron_id = ' + CAST(@p_patron_id AS VARCHAR)
	END
	
	
	IF @p_id IS NULL OR @p_id <= 0
	BEGIN
		IF @p_debug = 1
		BEGIN
			PRINT 'PRIMARY KEY IS NULL -- DOING A INSERT'
		END
		INSERT INTO dbo.checked_out_item
		(library_item_id, patron_id , date_checked_out, date_due)
		VALUES
		(@p_library_item_id, @p_patron_id, GETDATE(), GETDATE() + 14)
		
		SELECT @p_id = @@IDENTITY;
		
	END
	ELSE
	BEGIN
		IF @p_debug = 1
		BEGIN
			PRINT 'PRIMARY KEY IS VALID -- DOING AN UPDATE'
		END
		
		UPDATE dbo.checked_out_item
		SET 
		date_checked_in = GETDATE()
		WHERE id = @p_id
		
	END

END






GO

