USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_overdue]    Script Date: 12/08/2015 11:48:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_overdue]



AS
BEGIN
/*

exec usp_get_overdue 


*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Pretending books are overdue
-- todays date > due date 

	SELECT	c.id, l.title, l.isbn, p.first_name, p.last_name, p.phone, p.email, c.date_checked_out, c.date_due
	FROM	dbo.checked_out_item c JOIN dbo.library_item l ON (l.id = c.library_item_id)
			JOIN dbo.patron p ON (p.id = c.patron_id)
	WHERE	GETDATE() > date_due AND c.date_checked_in IS NULL

	
	/*
	SELECT	id, first_name, last_name, username, password, date_created, date_modified
	FROM	dbo.web_user
	WHERE	id			 = ISNULL(@p_id, id)
	AND		first_name	 = ISNULL(@p_first_name, first_name)
	AND		last_name	 = ISNULL(@p_last_name, last_name)
	AND		username	 = ISNULL(@p_username, username)
	AND		password	 = ISNULL(@p_password, password)
	*/
END





GO

