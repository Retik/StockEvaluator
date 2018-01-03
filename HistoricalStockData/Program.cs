using System;
using System.Linq;
using System.Threading.Tasks;
using Avapi;
using Avapi.AvapiTIME_SERIES_INTRADAY;
using StockSymbols;

namespace HistoricalStockData
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var container = Bootstrapper.Bootstrap();
                var stockInfo = StockSymbolInfo.Load();

                var stockEvaluator = container.GetInstance<StockEvaluator>();
                foreach (var stockSymbol in stockInfo.SymbolInfos.Where(s => s.Symbol == "AAPL"))
                {
                    var result = await stockEvaluator.Evaluate(stockSymbol);
                    Console.WriteLine($"{stockSymbol}: {result}");
                }

                //IAvapiConnection connection = AvapiConnection.Instance;
                //connection.Connect("P797GJNSWDAG952T");

                //var time_series_intraday = connection.GetQueryObject_TIME_SERIES_INTRADAY();
                //var response = time_series_intraday.Query("INTC",
                //    Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_interval.n_15min,
                //    Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_outputsize.full,
                //    Const_TIME_SERIES_INTRADAY.TIME_SERIES_INTRADAY_datatype.json);

                ////var time_series_daily = connection.GetQueryObject_TIME_SERIES_DAILY();
                ////var response = time_series_daily.Query("ABEO",
                ////    Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_outputsize.compact,
                ////    Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_datatype.json);

                //Console.WriteLine("******** RAW DATA ********");
                //Console.WriteLine(response.RawData);

                //Console.WriteLine("******** STRUCTURED DATA ********");
                //var data = response.Data;
                //if (data.Error)
                //{
                //    Console.WriteLine(data.ErrorMessage);
                //}
                //else
                //{
                //    Console.WriteLine("Information: " + data.MetaData.Information);
                //    Console.WriteLine("Symbol: " + data.MetaData.Symbol);
                //    Console.WriteLine("LastRefreshed: " + data.MetaData.LastRefreshed);
                //    Console.WriteLine("OutputSize: " + data.MetaData.OutputSize);
                //    Console.WriteLine("TimeZone: " + data.MetaData.TimeZone);
                //    Console.WriteLine("========================");
                //    Console.WriteLine("========================");
                //    foreach (var timeseries in data.TimeSeries)
                //    {
                //        Console.WriteLine("open: " + timeseries.open);
                //        Console.WriteLine("high: " + timeseries.high);
                //        Console.WriteLine("low: " + timeseries.low);
                //        Console.WriteLine("close: " + timeseries.close);
                //        Console.WriteLine("volume: " + timeseries.volume);
                //        Console.WriteLine("DateTime: " + timeseries.DateTime);
                //        Console.WriteLine("========================");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
