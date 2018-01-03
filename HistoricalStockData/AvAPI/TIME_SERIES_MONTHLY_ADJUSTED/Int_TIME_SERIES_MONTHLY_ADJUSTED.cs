using System.Collections.Generic;
namespace Avapi.AvapiTIME_SERIES_MONTHLY_ADJUSTED
{
    public interface Int_TIME_SERIES_MONTHLY_ADJUSTED
    {
		IAvapiResponse_TIME_SERIES_MONTHLY_ADJUSTED Query(
			string symbol,
			Const_TIME_SERIES_MONTHLY_ADJUSTED.TIME_SERIES_MONTHLY_ADJUSTED_datatype datatype = Const_TIME_SERIES_MONTHLY_ADJUSTED.TIME_SERIES_MONTHLY_ADJUSTED_datatype.none);


		IAvapiResponse_TIME_SERIES_MONTHLY_ADJUSTED Query(
			string symbol,
			string datatype = null);
	}

    public interface IAvapiResponse_TIME_SERIES_MONTHLY_ADJUSTED
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TIME_SERIES_MONTHLY_ADJUSTED_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TIME_SERIES_MONTHLY_ADJUSTED_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TIME_SERIES_MONTHLY_ADJUSTED MetaData
        {
            get;
        }

        IList <TimeSeries_Type_TIME_SERIES_MONTHLY_ADJUSTED> TimeSeries
        {
            get;
        }
    }
}
