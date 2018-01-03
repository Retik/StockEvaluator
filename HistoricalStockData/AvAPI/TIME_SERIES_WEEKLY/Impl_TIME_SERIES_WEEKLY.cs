using System; 
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Avapi.AvapiTIME_SERIES_WEEKLY
{
    internal class AvapiResponse_TIME_SERIES_WEEKLY : IAvapiResponse_TIME_SERIES_WEEKLY
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

        public IAvapiResponse_TIME_SERIES_WEEKLY_Content Data
        {
            get;
            internal set;
        }
    }

    public class MetaData_Type_TIME_SERIES_WEEKLY
    {
        public string Information
        {
            internal set;
            get;
        }

        public string Symbol
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

    public class TimeSeries_Type_TIME_SERIES_WEEKLY
    {
        public string open
        {
            internal set;
            get;
        }

        public string high
        {
            internal set;
            get;
        }

        public string low
        {
            internal set;
            get;
        }

        public string close
        {
            internal set;
            get;
        }

        public string volume
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

    internal class AvapiResponse_TIME_SERIES_WEEKLY_Content : IAvapiResponse_TIME_SERIES_WEEKLY_Content
    {
        internal AvapiResponse_TIME_SERIES_WEEKLY_Content()
        {
           MetaData = new MetaData_Type_TIME_SERIES_WEEKLY();
           TimeSeries = new List<TimeSeries_Type_TIME_SERIES_WEEKLY>();
        }

       public MetaData_Type_TIME_SERIES_WEEKLY MetaData
        {
            internal set;
            get;
        }

       public IList<TimeSeries_Type_TIME_SERIES_WEEKLY> TimeSeries
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

	public class Impl_TIME_SERIES_WEEKLY : Int_TIME_SERIES_WEEKLY
	{
		const string s_function = "TIME_SERIES_WEEKLY";

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

		private static readonly Lazy<Impl_TIME_SERIES_WEEKLY> s_Impl_TIME_SERIES_WEEKLY =
			new Lazy<Impl_TIME_SERIES_WEEKLY>(() => new Impl_TIME_SERIES_WEEKLY());
		public static Impl_TIME_SERIES_WEEKLY Instance
		{
			get
			{
				return s_Impl_TIME_SERIES_WEEKLY.Value;
			}
		}
		private Impl_TIME_SERIES_WEEKLY()
		{
		}

		internal static readonly IDictionary s_TIME_SERIES_WEEKLY_datatype_translation
			 = new Dictionary<Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype, string>()
		{
			{
				Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype.none,
				null
			},
			{
				Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype.json,
				"json"
			},
			{
				Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype.csv,
				"csv"
			}
		};

		 public IAvapiResponse_TIME_SERIES_WEEKLY Query(
			string symbol,
			Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype datatype = Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype.none)
		{
			string current_datatype = s_TIME_SERIES_WEEKLY_datatype_translation[datatype] as string;

			return Query(symbol,current_datatype);
		}


		 public IAvapiResponse_TIME_SERIES_WEEKLY Query(
			string symbol,
			string datatype = null)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			getParameters.Add(new KeyValuePair<string, string>("datatype",datatype));
			queryString += UrlUtility.AsQueryString(getParameters);

			// Sent the Request and get the raw data from the Response
			string response = RestClient?.
				GetAsync(queryString)?.
				Result?.
				Content?.
				ReadAsStringAsync()?.
				Result; 

			IAvapiResponse_TIME_SERIES_WEEKLY ret = new AvapiResponse_TIME_SERIES_WEEKLY
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

        static internal IAvapiResponse_TIME_SERIES_WEEKLY_Content ParseInternal(string jsonInput)
        {
            if (string.IsNullOrEmpty(jsonInput))
            {
                return null;
            }
            if(jsonInput == "{}")
            {
                return null;
            }

            AvapiResponse_TIME_SERIES_WEEKLY_Content ret = new AvapiResponse_TIME_SERIES_WEEKLY_Content();
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
                ret.MetaData.Symbol = (string)metaData["2. Symbol"];
                ret.MetaData.LastRefreshed = (string)metaData["3. Last Refreshed"];
                ret.MetaData.TimeZone = (string)metaData["4. Time Zone"];
                string timeSeries = "Weekly Time Series";
                JEnumerable<JToken> results = jsonInputParsed[timeSeries].Children();
                foreach (JToken result in results)
                {
                    TimeSeries_Type_TIME_SERIES_WEEKLY timeseries = new TimeSeries_Type_TIME_SERIES_WEEKLY
                    {
                        DateTime = ((JProperty)result).Name,
                        open = (string)result.First["1. open"],
                        high = (string)result.First["2. high"],
                        low = (string)result.First["3. low"],
                        close = (string)result.First["4. close"],
                        volume = (string)result.First["5. volume"]
                    };
                    ret.TimeSeries.Add(timeseries);
                }
            }
            return ret;
        }
	}
}