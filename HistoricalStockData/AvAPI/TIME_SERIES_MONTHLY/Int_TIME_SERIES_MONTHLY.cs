using System.Collections.Generic;
namespace Avapi.AvapiTIME_SERIES_MONTHLY
{
    public interface Int_TIME_SERIES_MONTHLY
    {
		IAvapiResponse_TIME_SERIES_MONTHLY Query(
			string symbol,
			Const_TIME_SERIES_MONTHLY.TIME_SERIES_MONTHLY_datatype datatype = Const_TIME_SERIES_MONTHLY.TIME_SERIES_MONTHLY_datatype.none);


		IAvapiResponse_TIME_SERIES_MONTHLY Query(
			string symbol,
			string datatype = null);
	}

    public interface IAvapiResponse_TIME_SERIES_MONTHLY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TIME_SERIES_MONTHLY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TIME_SERIES_MONTHLY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TIME_SERIES_MONTHLY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_TIME_SERIES_MONTHLY> TimeSeries
        {
            get;
        }
    }
}
