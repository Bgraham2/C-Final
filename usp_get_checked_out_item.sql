USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_checked_out_item]    Script Date: 12/08/2015 11:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_checked_out_item]

@p_id					bigint = NULL
, @p_library_item_id	bigint = NULL
, @p_patron_id			bigint = NULL
, @p_date_checked_out	datetime = NULL
, @p_date_due			datetime = NULL
, @p_date_checked_in	datetime = NULL


AS
BEGIN
/*


exec usp_get_checked_out_item NULL, NULL, NULL, NULL, NULL




*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT	id, library_item_id, patron_id, date_checked_out, date_due, date_checked_in
	FROM	dbo.checked_out_item
	WHERE	id					 = ISNULL(@p_id, id)
	AND		library_item_id	 = ISNULL(@p_library_item_id, library_item_id)
	AND		patron_id		 = ISNULL(@p_patron_id, patron_id)
	

END



GO

