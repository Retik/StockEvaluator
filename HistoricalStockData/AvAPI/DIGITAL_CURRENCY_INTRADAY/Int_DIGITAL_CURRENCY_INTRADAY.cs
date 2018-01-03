using System.Collections.Generic;
namespace Avapi.AvapiDIGITAL_CURRENCY_INTRADAY
{
    public interface Int_DIGITAL_CURRENCY_INTRADAY
    {
		IAvapiResponse_DIGITAL_CURRENCY_INTRADAY Query(
			string symbol,
			string market,
			Const_DIGITAL_CURRENCY_INTRADAY.DIGITAL_CURRENCY_INTRADAY_datatype datatype = Const_DIGITAL_CURRENCY_INTRADAY.DIGITAL_CURRENCY_INTRADAY_datatype.none);


		IAvapiResponse_DIGITAL_CURRENCY_INTRADAY Query(
			string symbol,
			string market,
			string datatype = null);
	}

    public interface IAvapiResponse_DIGITAL_CURRENCY_INTRADAY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_DIGITAL_CURRENCY_INTRADAY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_DIGITAL_CURRENCY_INTRADAY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_DIGITAL_CURRENCY_INTRADAY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_DIGITAL_CURRENCY_INTRADAY> TimeSeries
        {
            get;
        }
    }
}
