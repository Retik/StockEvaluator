using System.Collections.Generic;
namespace Avapi.AvapiTIME_SERIES_DAILY_ADJUSTED
{
    public interface Int_TIME_SERIES_DAILY_ADJUSTED
    {
		IAvapiResponse_TIME_SERIES_DAILY_ADJUSTED Query(
			string symbol,
			Const_TIME_SERIES_DAILY_ADJUSTED.TIME_SERIES_DAILY_ADJUSTED_outputsize outputsize = Const_TIME_SERIES_DAILY_ADJUSTED.TIME_SERIES_DAILY_ADJUSTED_outputsize.none,
			Const_TIME_SERIES_DAILY_ADJUSTED.TIME_SERIES_DAILY_ADJUSTED_datatype datatype = Const_TIME_SERIES_DAILY_ADJUSTED.TIME_SERIES_DAILY_ADJUSTED_datatype.none);


		IAvapiResponse_TIME_SERIES_DAILY_ADJUSTED Query(
			string symbol,
			string outputsize = null,
			string datatype = null);
	}

    public interface IAvapiResponse_TIME_SERIES_DAILY_ADJUSTED
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TIME_SERIES_DAILY_ADJUSTED_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TIME_SERIES_DAILY_ADJUSTED_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TIME_SERIES_DAILY_ADJUSTED MetaData
        {
            get;
        }

        IList <TimeSeries_Type_TIME_SERIES_DAILY_ADJUSTED> TimeSeries
        {
            get;
        }
    }
}
