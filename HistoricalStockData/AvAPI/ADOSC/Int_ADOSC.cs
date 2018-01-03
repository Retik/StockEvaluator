using System.Collections.Generic;
namespace Avapi.AvapiADOSC
{
    public interface Int_ADOSC
    {
		IAvapiResponse_ADOSC Query(
			string symbol,
			Const_ADOSC.ADOSC_interval interval,
			int fastperiod = -1,
			int slowperiod = -1);


		IAvapiResponse_ADOSC Query(
			string symbol,
			string interval,
			int fastperiod = -1,
			int slowperiod = -1);
	}

    public interface IAvapiResponse_ADOSC
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_ADOSC_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_ADOSC_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_ADOSC MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_ADOSC> TechnicalIndicator
        {
            get;
        }
    }
}
