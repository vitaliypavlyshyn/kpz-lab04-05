﻿namespace QQQQ
{
    public class HistoricalEventEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public List<ReasonEntity>? Reasons { get; set; }
        public List<ConsequenceEntity>? Consequence { get; set; }
    }
}
