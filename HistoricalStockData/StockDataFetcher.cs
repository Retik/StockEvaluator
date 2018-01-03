using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avapi;
using Avapi.AvapiTIME_SERIES_INTRADAY;
using StockSymbols;

namespace HistoricalStockData
{
    public class StockDataFetcher
    {
        private readonly IAvapiConnection connection;
        private const string APIKEY = "P797GJNSWDAG952T";

        public StockDataFetcher()
        {
            connection = AvapiConnection.Instance;
            connection.Connect(APIKEY);
        }

        public async Task<StockDataDay[]> GetFullDataAsync(SymbolInfo info)
        {
            var time_series_intraday = connection.GetQueryObject_TIME_SERIES_INTRADAY();
            var response = await time_series_intraday.QueryAsync(info.Symbol,
                Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_interval.n_5min,
                Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_outputsize.full,
                Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_datatype.json);

            if(response.Data.Error)
                throw new Exception(response.Data.ErrorMessage);

            var data = ParseStockData(response.Data);
            var dataGroups = data.GroupBy(d => d.Timestamp.Date);
            return dataGroups.Select(group => new StockDataDay
            {
                Day = new DateTime(group.Key.Year, group.Key.Month, group.Key.Day),
                Data = @group.ToArray()
            }).ToArray();
        }

        public async Task<StockDataDay> GetLastDayDataAsync(SymbolInfo info)
        {
            var time_series_intraday = connection.GetQueryObject_TIME_SERIES_INTRADAY();
            var response = await time_series_intraday.QueryAsync(info.Symbol,
                Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_interval.n_5min,
                Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_outputsize.compact,
                Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_datatype.json);

            if(response.Data.Error)
                throw new Exception(response.Data.ErrorMessage);

            var data = ParseStockData(response.Data);
            var dataGroups = data.GroupBy(d => d.Timestamp.Date).ToList();
            return new StockDataDay
            {
                Day = new DateTime(dataGroups.First().Key.Year, dataGroups.First().Key.Month, dataGroups.First().Key.Day),
                Data = dataGroups.First().ToArray()
            };
        }

        private IEnumerable<StockDataPoint> ParseStockData(IAvapiResponse_TIME_SERIES_INTRADAY_Content data)
        {
            var dataPoints = new List<StockDataPoint>();
            foreach (var point in data.TimeSeries)
            {
                try
                {
                    dataPoints.Add(new StockDataPoint
                    {
                        Timestamp = DateTime.Parse(point.DateTime),
                        Close = double.Parse(point.close),
                        High = double.Parse(point.high),
                        Low = double.Parse(point.low),
                        Open = double.Parse(point.open),
                        Volume = double.Parse(point.volume)
                    });
                }
                catch (Exception ex) {}
            }
            return dataPoints.ToArray();
        }
    }
}
