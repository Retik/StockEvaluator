using System.Collections.Generic;
namespace Avapi.AvapiTIME_SERIES_DAILY
{
    public interface Int_TIME_SERIES_DAILY
    {
		IAvapiResponse_TIME_SERIES_DAILY Query(
			string symbol,
			Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_outputsize outputsize = Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_outputsize.none,
			Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_datatype datatype = Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_datatype.none);


		IAvapiResponse_TIME_SERIES_DAILY Query(
			string symbol,
			string outputsize = null,
			string datatype = null);
	}

    public interface IAvapiResponse_TIME_SERIES_DAILY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TIME_SERIES_DAILY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TIME_SERIES_DAILY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TIME_SERIES_DAILY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_TIME_SERIES_DAILY> TimeSeries
        {
            get;
        }
    }
}
