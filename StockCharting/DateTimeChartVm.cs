using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Media;
using HistoricalStockData;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using StockCharting.Annotations;
using StockSymbols;

namespace StockCharting
{
    public class DateTimeChartVm : INotifyPropertyChanged
    {
        private readonly StockDataFetcher stockDataFetcher = new StockDataFetcher();
        private readonly StockSymbolInfo symbolInfo = StockSymbolInfo.Load();
        public DateTimeChartVm()
        {
            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double) dayModel.DateTime.Ticks/TimeSpan.FromHours(1).Ticks)
                .Y(dayModel => dayModel.Value);
 
            //Notice you can also configure this type globally, so you don't need to configure every
            //SeriesCollection instance using the type.
            //more info at http://lvcharts.net/App/Index#/examples/v1/wpf/Types%20and%20Configuration

            StockDataSeries = new GLineSeries
            {
                Title = "Intraday",
                Values = new GearedValues<DateModel>(),
                Fill = Brushes.Transparent
            };
            StockOpenSeries = new GLineSeries
            {
                Title = "Open",
                Values = new GearedValues<DateModel>(),
                Fill = Brushes.Transparent,
            };

            Series = new SeriesCollection(dayConfig)
            {
                StockDataSeries,
                StockOpenSeries
            };
 
            Formatter = value => new System.DateTime((long) (value*TimeSpan.FromHours(1).Ticks)).ToString("t");
            ChartStockCommand = new AwaitableDelegateCommand(ChartStockCommandExecute);
        }

        private async Task ChartStockCommandExecute()
        {
            try
            {
                StockDataSeries.Values.Clear();
                StockOpenSeries.Values.Clear();
                var stockInfo = symbolInfo.SymbolInfos.SingleOrDefault(s => s.Symbol != null && s.Symbol.Equals(StockSymbol, StringComparison.InvariantCultureIgnoreCase));
                if (stockInfo == null)
                {
                    Status = "Invalid stock symbol";
                }
                else
                {
                    Status = "Loading";
                    var data = await stockDataFetcher.GetLastDayDataAsync(stockInfo);
                    StockOpenSeries.Values.AddRange(new[]
                    {
                        new DateModel{DateTime = data.Data.Last().Timestamp, Value = data.Data.Last().Open}, 
                        new DateModel{DateTime = data.Data.First().Timestamp, Value = data.Data.Last().Open}
                    });
                    StockDataSeries.Values.AddRange(data.Data.Select(d => new DateModel { DateTime = d.Timestamp, Value = d.Close }));
                    Status = "Load Complete";
                }
            }
            catch (Exception e)
            {
                Status = $"Error: {e.Message}";
            }
        }

        private LineSeries StockDataSeries { get;set; }
        private LineSeries StockOpenSeries { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection Series { get; set; }
        public IAsyncCommand ChartStockCommand { get; set; }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        private string stockSymbol;
        public string StockSymbol
        {
            get { return stockSymbol; }
            set
            {
                stockSymbol = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
