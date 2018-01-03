using SimpleInjector;

namespace HistoricalStockData
{
    public static class Bootstrapper
    {
        public static Container Bootstrap()
        {
            var container = new Container();
            
            container.Register<StockDataFetcher>();
            container.Register<StockEvaluator>();
            container.Verify();

            return container;
        }
    }
}
