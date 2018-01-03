using System.Collections.Generic;
namespace Avapi.AvapiDIGITAL_CURRENCY_DAILY
{
    public interface Int_DIGITAL_CURRENCY_DAILY
    {
		IAvapiResponse_DIGITAL_CURRENCY_DAILY Query(
			string symbol,
			string market,
			Const_DIGITAL_CURRENCY_DAILY.DIGITAL_CURRENCY_DAILY_datatype datatype = Const_DIGITAL_CURRENCY_DAILY.DIGITAL_CURRENCY_DAILY_datatype.none);


		IAvapiResponse_DIGITAL_CURRENCY_DAILY Query(
			string symbol,
			string market,
			string datatype = null);
	}

    public interface IAvapiResponse_DIGITAL_CURRENCY_DAILY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_DIGITAL_CURRENCY_DAILY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_DIGITAL_CURRENCY_DAILY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_DIGITAL_CURRENCY_DAILY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_DIGITAL_CURRENCY_DAILY> TimeSeries
        {
            get;
        }
    }
}
