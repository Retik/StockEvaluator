using System.Collections.Generic;
namespace Avapi.AvapiTIME_SERIES_WEEKLY
{
    public interface Int_TIME_SERIES_WEEKLY
    {
		IAvapiResponse_TIME_SERIES_WEEKLY Query(
			string symbol,
			Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype datatype = Const_TIME_SERIES_WEEKLY.TIME_SERIES_WEEKLY_datatype.none);


		IAvapiResponse_TIME_SERIES_WEEKLY Query(
			string symbol,
			string datatype = null);
	}

    public interface IAvapiResponse_TIME_SERIES_WEEKLY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TIME_SERIES_WEEKLY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TIME_SERIES_WEEKLY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TIME_SERIES_WEEKLY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_TIME_SERIES_WEEKLY> TimeSeries
        {
            get;
        }
    }
}
