using System.Collections.Generic;
namespace Avapi.AvapiDIGITAL_CURRENCY_MONTHLY
{
    public interface Int_DIGITAL_CURRENCY_MONTHLY
    {
		IAvapiResponse_DIGITAL_CURRENCY_MONTHLY Query(
			string symbol,
			string market,
			Const_DIGITAL_CURRENCY_MONTHLY.DIGITAL_CURRENCY_MONTHLY_datatype datatype = Const_DIGITAL_CURRENCY_MONTHLY.DIGITAL_CURRENCY_MONTHLY_datatype.none);


		IAvapiResponse_DIGITAL_CURRENCY_MONTHLY Query(
			string symbol,
			string market,
			string datatype = null);
	}

    public interface IAvapiResponse_DIGITAL_CURRENCY_MONTHLY
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_DIGITAL_CURRENCY_MONTHLY_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_DIGITAL_CURRENCY_MONTHLY_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_DIGITAL_CURRENCY_MONTHLY MetaData
        {
            get;
        }

        IList <TimeSeries_Type_DIGITAL_CURRENCY_MONTHLY> TimeSeries
        {
            get;
        }
    }
}
