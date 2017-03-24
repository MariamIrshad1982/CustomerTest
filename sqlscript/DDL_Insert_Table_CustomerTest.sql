IF NOT EXISTS(SELECT id FROM SYSOBJECTS WHERE name = 'CustomerTest') 
CREATE TABLE [dbo].[CustomerTest](
	[ID] [int] NOT NULL,
	[Name] [varchar](60) NULL,
	[Status] [smallint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](20) NULL,
 CONSTRAINT [PK_CustomerTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
