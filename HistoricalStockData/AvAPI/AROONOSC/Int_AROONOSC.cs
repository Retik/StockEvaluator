using System.Collections.Generic;
namespace Avapi.AvapiAROONOSC
{
    public interface Int_AROONOSC
    {
		IAvapiResponse_AROONOSC Query(
			string symbol,
			Const_AROONOSC.AROONOSC_interval interval,
			int time_period);


		IAvapiResponse_AROONOSC Query(
			string symbol,
			string interval,
			int time_period);
	}

    public interface IAvapiResponse_AROONOSC
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_AROONOSC_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_AROONOSC_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_AROONOSC MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_AROONOSC> TechnicalIndicator
        {
            get;
        }
    }
}
