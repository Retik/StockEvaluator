using System.Collections.Generic;
namespace Avapi.AvapiATR
{
    public interface Int_ATR
    {
		IAvapiResponse_ATR Query(
			string symbol,
			Const_ATR.ATR_interval interval,
			int time_period);


		IAvapiResponse_ATR Query(
			string symbol,
			string interval,
			int time_period);
	}

    public interface IAvapiResponse_ATR
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_ATR_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_ATR_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_ATR MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_ATR> TechnicalIndicator
        {
            get;
        }
    }
}
