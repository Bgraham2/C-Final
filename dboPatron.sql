USE [final]
GO

/****** Object:  Table [dbo].[patron]    Script Date: 12/08/2015 11:46:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[patron](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[patron_type_id] [bigint] NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[active] [bit] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
 CONSTRAINT [PK_patron] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[patron] ADD  CONSTRAINT [DF_patron_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[patron] ADD  CONSTRAINT [DF_patron_date_modified]  DEFAULT (getdate()) FOR [date_modified]
GO

