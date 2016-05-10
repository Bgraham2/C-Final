USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_checkedout]    Script Date: 12/08/2015 11:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_checkedout]

@p_id					bigint = NULL
, @p_library_item_id	bigint = NULL

AS
BEGIN
/*

exec usp_get_checkedout 1


*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Pretending books are overdue
-- todays date > due date 

	SELECT	c.id, l.id, l.title, l.isbn, c.date_checked_out, c.date_due, c.date_checked_in
	FROM	dbo.checked_out_item c JOIN dbo.library_item l ON (l.id = c.library_item_id)
			JOIN dbo.patron p ON (p.id = c.patron_id)
	WHERE	@p_id = c.patron_id AND c.date_checked_in IS NULL

	

END






GO

