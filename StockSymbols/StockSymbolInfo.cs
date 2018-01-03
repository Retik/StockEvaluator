using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace StockSymbols
{
    [XmlRoot("StockSymbolInfo")]
    public class StockSymbolInfo
    {
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(StockSymbolInfo));
        public static StockSymbolInfo Load()
        {
            return serializer.Deserialize<StockSymbolInfo>(File.ReadAllText(@"StockSymbolInfo\StockInfo.xml"));
        }

        public static void Save(StockSymbolInfo info)
        {
            info.SymbolInfos = info.SymbolInfos.OrderBy(i => i.Name).ToArray();
            using(var stream = new FileStream(@"StockSymbolInfo\StockInfoNew.xml", FileMode.OpenOrCreate))
                serializer.Serialize(stream, info);
        }

        [XmlElement("SymbolInfo")]
        public SymbolInfo[] SymbolInfos { get;set; }
    }

    public class SymbolInfo
    {
        public string Symbol { get;set; }
        public string Name { get; set; }
        public double? LastSale { get; set; }
        public double? MarketCap { get; set; }
        public int? IPOyear { get;set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Summary { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Symbol})";
        }
    }
}
