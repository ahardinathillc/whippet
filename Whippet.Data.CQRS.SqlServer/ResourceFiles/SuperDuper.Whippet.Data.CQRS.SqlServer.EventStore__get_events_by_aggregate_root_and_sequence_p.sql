CREATE OR ALTER PROCEDURE [whippet].[EventStore__get_events_by_aggregate_root_and_sequence_p] 
	@aggregateRootId UNIQUEIDENTIFIER,
	@sequence INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		[es].[EventType],
		[es].[Data]
	FROM
		[whippet].[EventStore] [es]
	WHERE
		[es].[AggregateRootId] = @aggregateRootId
			AND [es].[Sequence] = @sequence
END
