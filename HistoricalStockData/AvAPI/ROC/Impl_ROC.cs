using System; 
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Avapi.AvapiROC
{
    internal class AvapiResponse_ROC : IAvapiResponse_ROC
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

        public IAvapiResponse_ROC_Content Data
        {
            get;
            internal set;
        }
    }

    public class MetaData_Type_ROC
    {
        public string Symbol
        {
            internal set;
            get;
        }

        public string Indicator
        {
            internal set;
            get;
        }

        public string LastRefreshed
        {
            internal set;
            get;
        }

        public string Interval
        {
            internal set;
            get;
        }

        public string TimePeriod
        {
            internal set;
            get;
        }

        public string SeriesType
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

    public class TechnicalIndicator_Type_ROC
    {
        public string ROC
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

    internal class AvapiResponse_ROC_Content : IAvapiResponse_ROC_Content
    {
        internal AvapiResponse_ROC_Content()
        {
           MetaData = new MetaData_Type_ROC();
           TechnicalIndicator = new List<TechnicalIndicator_Type_ROC>();
        }

       public MetaData_Type_ROC MetaData
        {
            internal set;
            get;
        }

       public IList<TechnicalIndicator_Type_ROC> TechnicalIndicator
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

	public class Impl_ROC : Int_ROC
	{
		const string s_function = "ROC";

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

		private static readonly Lazy<Impl_ROC> s_Impl_ROC =
			new Lazy<Impl_ROC>(() => new Impl_ROC());
		public static Impl_ROC Instance
		{
			get
			{
				return s_Impl_ROC.Value;
			}
		}
		private Impl_ROC()
		{
		}

		internal static readonly IDictionary s_ROC_interval_translation
			 = new Dictionary<Const_ROC.ROC_interval, string>()
		{
			{
				Const_ROC.ROC_interval.none,
				null
			},
			{
				Const_ROC.ROC_interval.n_1min,
				"1min"
			},
			{
				Const_ROC.ROC_interval.n_5min,
				"5min"
			},
			{
				Const_ROC.ROC_interval.n_15min,
				"15min"
			},
			{
				Const_ROC.ROC_interval.n_30min,
				"30min"
			},
			{
				Const_ROC.ROC_interval.n_60min,
				"60min"
			},
			{
				Const_ROC.ROC_interval.daily,
				"daily"
			},
			{
				Const_ROC.ROC_interval.weekly,
				"weekly"
			},
			{
				Const_ROC.ROC_interval.monthly,
				"monthly"
			}
		};

		internal static readonly IDictionary s_ROC_series_type_translation
			 = new Dictionary<Const_ROC.ROC_series_type, string>()
		{
			{
				Const_ROC.ROC_series_type.none,
				null
			},
			{
				Const_ROC.ROC_series_type.close,
				"close"
			},
			{
				Const_ROC.ROC_series_type.open,
				"open"
			},
			{
				Const_ROC.ROC_series_type.high,
				"high"
			},
			{
				Const_ROC.ROC_series_type.low,
				"low"
			}
		};

		 public IAvapiResponse_ROC Query(
			string symbol,
			Const_ROC.ROC_interval interval,
			int time_period,
			Const_ROC.ROC_series_type series_type)
		{
			string current_interval = s_ROC_interval_translation[interval] as string;
			string current_series_type = s_ROC_series_type_translation[series_type] as string;

			return Query(symbol,current_interval,time_period,current_series_type);
		}


		 public IAvapiResponse_ROC Query(
			string symbol,
			string interval,
			int time_period,
			string series_type)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			getParameters.Add(new KeyValuePair<string, string>("interval",interval));
			getParameters.Add(new KeyValuePair<string, string>("time_period",time_period.ToString()));
			getParameters.Add(new KeyValuePair<string, string>("series_type",series_type));
			queryString += UrlUtility.AsQueryString(getParameters);

			// Sent the Request and get the raw data from the Response
			string response = RestClient?.
				GetAsync(queryString)?.
				Result?.
				Content?.
				ReadAsStringAsync()?.
				Result; 

			IAvapiResponse_ROC ret = new AvapiResponse_ROC
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

        static internal IAvapiResponse_ROC_Content ParseInternal(string jsonInput)
        {
            if (string.IsNullOrEmpty(jsonInput))
            {
                return null;
            }
            if(jsonInput == "{}")
            {
                return null;
            }

            AvapiResponse_ROC_Content ret = new AvapiResponse_ROC_Content();
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
                ret.MetaData.Symbol = (string)metaData["1: Symbol"];
                ret.MetaData.Indicator = (string)metaData["2: Indicator"];
                ret.MetaData.LastRefreshed = (string)metaData["3: Last Refreshed"];
                ret.MetaData.Interval = (string)metaData["4: Interval"];
                ret.MetaData.TimePeriod = (string)metaData["5: Time Period"];
                ret.MetaData.SeriesType = (string)metaData["6: Series Type"];
                ret.MetaData.TimeZone = (string)metaData["7: Time Zone"];
                JEnumerable<JToken> results = jsonInputParsed["Technical Analysis: ROC"].Children();
                foreach (JToken result in results)
                {
                    TechnicalIndicator_Type_ROC technicalindicator = new TechnicalIndicator_Type_ROC
                    {
                        DateTime = ((JProperty)result).Name,
                        ROC = (string)result.First["ROC"]
                    };
                    ret.TechnicalIndicator.Add(technicalindicator);
                }
            }
            return ret;
        }
	}
}