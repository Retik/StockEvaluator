using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace StockSymbols
{
    public static class ExtensionMethods
    {
        private static string RemoveText(Match m) { return "";}
        public static T Deserialize<T>(this XmlSerializer serializer, string xml){
            string cleanXml = Regex.Replace(xml, @"<[a-zA-Z].[^(><.)]+/>", RemoveText);
            MemoryStream memoryStream = new MemoryStream((new UTF8Encoding()).GetBytes(cleanXml));
            return (T)serializer.Deserialize(memoryStream);
        }

        public static double? ConvertFromMarketCap(this string marketCapString)
        {
            var stringAmount = marketCapString.TrimStart('$').TrimEnd('M', 'B');
            if (stringAmount.Equals("n/a"))
                return null;

            var amount = double.Parse(stringAmount);

            if(marketCapString.EndsWith("M"))
                return amount * 1e6;
            if (marketCapString.EndsWith("B"))
                return amount * 1e9;
            return amount;
        }
    }
}
