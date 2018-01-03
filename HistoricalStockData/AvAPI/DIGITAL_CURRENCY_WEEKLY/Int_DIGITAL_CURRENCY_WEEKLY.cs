using System.Collections.Generic;
namespace Avapi.AvapiDIGITAL_CURRENCY_WEEKLY
{
    public interface Int_DIGITAL_CURRENCY_WEEKLY
    {
		IAvapiResponse_DIGITAL_CURRENCY_WEEKLY Query(
			string symbol,
			string market,
			Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype datatype = Const_DIGITAL_CURRENCY_WEEKLY.DIGITAL_CURRENCY_WEEKLY_datatype.none);


		IAvapiResponse_DIGITAL_CURRENCY_WEEKLY Query(
			string symbol,
			string market,
			string datatype = null);
	}

    public interface IAvapiResponse_DIGITAL_CURRENCY_WEEKLY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_DIGITAL_CURRENCY_WEEKLY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_DIGITAL_CURRENCY_WEEKLY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_DIGITAL_CURRENCY_WEEKLY> TimeSeries
        {
            get;
        }
    }
}
