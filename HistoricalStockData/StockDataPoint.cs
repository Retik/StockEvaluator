using System;

namespace HistoricalStockData
{
    public class StockDataPoint
    {
        public DateTime Timestamp { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }

    public class StockDataDay
    {
        public DateTime Day { get; set; }
        public StockDataPoint[] Data { get;set; }
    }
}
