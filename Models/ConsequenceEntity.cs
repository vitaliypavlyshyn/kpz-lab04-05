namespace QQQQ
{
    public class ConsequenceEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int EventId { get; set; }
        public HistoricalEventEntity? Event { get; set; }
    }
}
