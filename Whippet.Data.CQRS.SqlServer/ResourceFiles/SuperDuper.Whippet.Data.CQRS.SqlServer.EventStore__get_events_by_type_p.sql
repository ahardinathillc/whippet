CREATE OR ALTER PROCEDURE [whippet].[EventStore__get_events_by_type_p]
	@eventType			NVARCHAR(MAX),
	@aggregateRootId    UNIQUEIDENTIFIER NULL
AS
BEGIN
	SELECT 
		*
	FROM 
		[whippet].[EventStore] [es]
	WHERE 
		[es].[EventType] IN (SELECT value FROM STRING_SPLIT(@eventType, ','))
			AND ((@aggregateRootId IS NOT NULL AND [es].[AggregateRootId] = @aggregateRootId) OR (@aggregateRootId IS NULL))
END