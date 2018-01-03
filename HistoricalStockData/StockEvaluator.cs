using System.Threading.Tasks;
using StockSymbols;

namespace HistoricalStockData
{
    public class StockEvaluator
    {
        private readonly StockDataFetcher stockDataFetcher;
        public StockEvaluator(StockDataFetcher sdf)
        {
            stockDataFetcher = sdf;
        }

        public async Task<bool> Evaluate(SymbolInfo info)
        {
            var result = false;
            var stockData = await stockDataFetcher.GetFullDataAsync(info);
            return result;
        }
    }
}
