using System.Collections.Generic;
namespace Avapi.AvapiMIDPRICE
{
    public interface Int_MIDPRICE
    {
		IAvapiResponse_MIDPRICE Query(
			string symbol,
			Const_MIDPRICE.MIDPRICE_interval interval,
			int time_period);


		IAvapiResponse_MIDPRICE Query(
			string symbol,
			string interval,
			int time_period);
	}

    public interface IAvapiResponse_MIDPRICE
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_MIDPRICE_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_MIDPRICE_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_MIDPRICE MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_MIDPRICE> TechnicalIndicator
        {
            get;
        }
    }
}
