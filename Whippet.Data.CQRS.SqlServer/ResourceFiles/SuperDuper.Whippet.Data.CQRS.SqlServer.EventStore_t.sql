IF (SELECT [object_id] FROM [sys].[tables] WHERE [name] = 'EventStore' AND SCHEMA_NAME(schema_id) = 'whippet') IS NULL
BEGIN
	CREATE TABLE [whippet].[EventStore](
		[EventId] [int] IDENTITY(1,1) NOT NULL,
		[EventType] [nvarchar](255) NULL,
		[AggregateRootId] [uniqueidentifier] NOT NULL,
		[EventDate] [datetime] NOT NULL,
		[Sequence] [int] NOT NULL,
		[Data] [nvarchar](max) NULL,
	 CONSTRAINT [PK_EventStore] PRIMARY KEY CLUSTERED 
	(
		[EventId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END