using System.Collections.Generic;
namespace Avapi.AvapiHT_TRENDLINE
{
    public interface Int_HT_TRENDLINE
    {
		IAvapiResponse_HT_TRENDLINE Query(
			string symbol,
			Const_HT_TRENDLINE.HT_TRENDLINE_interval interval,
			Const_HT_TRENDLINE.HT_TRENDLINE_series_type series_type);


		IAvapiResponse_HT_TRENDLINE Query(
			string symbol,
			string interval,
			string series_type);
	}

    public interface IAvapiResponse_HT_TRENDLINE
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_HT_TRENDLINE_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_HT_TRENDLINE_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_HT_TRENDLINE MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_HT_TRENDLINE> TechnicalIndicator
        {
            get;
        }
    }
}
