using System; 
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Avapi.AvapiDIGITAL_CURRENCY_WEEKLY
{
    internal class AvapiResponse_DIGITAL_CURRENCY_WEEKLY : IAvapiResponse_DIGITAL_CURRENCY_WEEKLY
    {
        public string LastHttpRequest
        {
            get;
            internal set;

        }
        public string RawData
        {
            get;
            internal set;
        }

        public IAvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content Data
        {
            get;
            internal set;
        }
    }

    public class MetaData_Type_DIGITAL_CURRENCY_WEEKLY
    {
        public string Information
        {
            internal set;
            get;
        }

        public string DigitalCurrencyCode
        {
            internal set;
            get;
        }

        public string DigitalCurrencyName
        {
            internal set;
            get;
        }

        public string MarketCode
        {
            internal set;
            get;
        }

        public string MarketName
        {
            internal set;
            get;
        }

        public string LastRefreshed
        {
            internal set;
            get;
        }

        public string TimeZone
        {
            internal set;
            get;
        }

    }

    public class TimeSeries_Type_DIGITAL_CURRENCY_WEEKLY
    {
        public string Open
        {
            internal set;
            get;
        }

        public string OpenUSD
        {
            internal set;
            get;
        }

        public string High
        {
            internal set;
            get;
        }

        public string HighUSD
        {
            internal set;
            get;
        }

        public string Low
        {
            internal set;
            get;
        }

        public string LowUSD
        {
            internal set;
            get;
        }

        public string Close
        {
            internal set;
            get;
        }

        public string CloseUSD
        {
            internal set;
            get;
        }

        public string Volume
        {
            internal set;
            get;
        }

        public string MarketCapUSD
        {
            internal set;
            get;
        }

        public string DateTime
        {
            internal set;
            get;
        }

    }

    internal class AvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content : IAvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content
    {
        internal AvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content()
        {
           MetaData = new MetaData_Type_DIGITAL_CURRENCY_WEEKLY();
           TimeSeries = new List<TimeSeries_Type_DIGITAL_CURRENCY_WEEKLY>();
        }

       public MetaData_Type_DIGITAL_CURRENCY_WEEKLY MetaData
        {
            internal set;
            get;
        }

       public IList<TimeSeries_Type_DIGITAL_CURRENCY_WEEKLY> TimeSeries
        {
            internal set;
            get;
        }

        public bool Error
        {
            internal set;
            get;
        }

        public string ErrorMessage
        {
            internal set;
            get;
        }
    }

	public class Impl_DIGITAL_CURRENCY_WEEKLY : Int_DIGITAL_CURRENCY_WEEKLY
	{
		const string s_function = "DIGITAL_CURRENCY_WEEKLY";

		internal static string ApiKey
		{
			get;
			set;
		}

		internal static HttpClient RestClient
		{
			get;
			set;
		}

		internal static string AvapiUrl
		{
			get;
			set;
		}

		private static readonly Lazy<Impl_DIGITAL_CURRENCY_WEEKLY> s_Impl_DIGITAL_CURRENCY_WEEKLY =
			new Lazy<Impl_DIGITAL_CURRENCY_WEEKLY>(() => new Impl_DIGITAL_CURRENCY_WEEKLY());
		public static Impl_DIGITAL_CURRENCY_WEEKLY Instance
		{
			get
			{
				return s_Impl_DIGITAL_CURRENCY_WEEKLY.Value;
			}
		}
		private Impl_DIGITAL_CURRENCY_WEEKLY()
		{
		}

		internal static readonly IDictionary s_DIGITAL_CURRENCY_WEEKLY_datatype_translation
			 = new Dictionary<Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype, string>()
		{
			{
				Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype.none,
				null
			},
			{
				Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype.json,
				"json"
			},
			{
				Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype.csv,
				"csv"
			}
		};

		 public IAvapiResponse_DIGITAL_CURRENCY_WEEKLY Query(
			string symbol,
			string market,
			Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype datatype = Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype.none)
		{
			string current_datatype = s_DIGITAL_CURRENCY_WEEKLY_datatype_translation[datatype] as string;

			return Query(symbol,market,current_datatype);
		}


		 public IAvapiResponse_DIGITAL_CURRENCY_WEEKLY Query(
			string symbol,
			string market,
			string datatype = null)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			getParameters.Add(new KeyValuePair<string, string>("market",market));
			getParameters.Add(new KeyValuePair<string, string>("datatype",datatype));
			queryString += UrlUtility.AsQueryString(getParameters);

			// Sent the Request and get the raw data from the Response
			string response = RestClient?.
				GetAsync(queryString)?.
				Result?.
				Content?.
				ReadAsStringAsync()?.
				Result; 

			IAvapiResponse_DIGITAL_CURRENCY_WEEKLY ret = new AvapiResponse_DIGITAL_CURRENCY_WEEKLY
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

        static internal IAvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content ParseInternal(string jsonInput)
        {
            if (string.IsNullOrEmpty(jsonInput))
            {
                return null;
            }
            if(jsonInput == "{}")
            {
                return null;
            }

            AvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content ret = new AvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content();
            JObject jsonInputParsed = JObject.Parse(jsonInput);
            string errorMessage = (string)jsonInputParsed["Error Message"];
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ret.Error = true;
                ret.ErrorMessage = errorMessage;
            }
            else
            {
                JToken metaData = jsonInputParsed["Meta Data"];
                ret.MetaData.Information = (string)metaData["1. Information"];
                ret.MetaData.DigitalCurrencyCode = (string)metaData["2. Digital Currency Code"];
                ret.MetaData.DigitalCurrencyName = (string)metaData["3. Digital Currency Name"];
                ret.MetaData.MarketCode = (string)metaData["4. Market Code"];
                ret.MetaData.MarketName = (string)metaData["5. Market Name"];
                ret.MetaData.LastRefreshed = (string)metaData["6. Last Refreshed"];
                ret.MetaData.TimeZone = (string)metaData["7. Time Zone"];
                string timeSeries = "Time Series (Digital Currency Weekly)";
                JEnumerable<JToken> results = jsonInputParsed[timeSeries].Children();
                foreach (JToken result in results)
                {
                    TimeSeries_Type_DIGITAL_CURRENCY_WEEKLY timeseries = new TimeSeries_Type_DIGITAL_CURRENCY_WEEKLY
                    {
                        DateTime = ((JProperty)result).Name,
                        Open = (string)result.First["1a. open (" + ret.MetaData.MarketCode + ")"],
                        OpenUSD = (string)result.First["1b. open (USD)"],
                        High = (string)result.First["2a. high (" + ret.MetaData.MarketCode + ")"],
                        HighUSD = (string)result.First["2b. high (USD)"],
                        Low = (string)result.First["3a. low (" + ret.MetaData.MarketCode + ")"],
                        LowUSD = (string)result.First["3b. low (USD)"],
                        Close = (string)result.First["4a. close (" + ret.MetaData.MarketCode + ")"],
                        CloseUSD = (string)result.First["4b. close (USD)"],
                        Volume = (string)result.First["5. volume"],
                        MarketCapUSD = (string)result.First["6. market cap (USD)"]
                    };
                    ret.TimeSeries.Add(timeseries);
                }
            }
            return ret;
        }
	}
}