CREATE OR ALTER PROCEDURE [whippet].[EventStore__insert_event_p]
	@eventType			NVARCHAR(255),
	@aggregateRootId	UNIQUEIDENTIFIER,
	@eventDate			DATETIME,
	@sequence			INT,
	@data				NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO [whippet].[EventStore]([EventType],[AggregateRootId],[EventDate],[Sequence],[Data]) VALUES(@eventType, @aggregateRootId, @eventDate, @sequence, @data)
END
