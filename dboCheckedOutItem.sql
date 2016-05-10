USE [final]
GO

/****** Object:  Table [dbo].[checked_out_item]    Script Date: 12/08/2015 11:45:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[checked_out_item](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[library_item_id] [bigint] NOT NULL,
	[patron_id] [bigint] NOT NULL,
	[date_checked_out] [datetime] NOT NULL,
	[date_due] [datetime] NOT NULL,
	[date_checked_in] [datetime] NULL,
 CONSTRAINT [PK_checked_out_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[checked_out_item] ADD  CONSTRAINT [DF_checked_out_item_date_checked_out]  DEFAULT (getdate()) FOR [date_checked_out]
GO

ALTER TABLE [dbo].[checked_out_item] ADD  CONSTRAINT [DF_checked_out_item_date_due]  DEFAULT (getdate()+(14)) FOR [date_due]
GO

