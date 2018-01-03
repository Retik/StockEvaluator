using System.Collections.Generic;
namespace Avapi.AvapiWILLR
{
    public interface Int_WILLR
    {
		IAvapiResponse_WILLR Query(
			string symbol,
			Const_WILLR.WILLR_interval interval,
			int time_period);


		IAvapiResponse_WILLR Query(
			string symbol,
			string interval,
			int time_period);
	}

    public interface IAvapiResponse_WILLR
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_WILLR_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_WILLR_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_WILLR MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_WILLR> TechnicalIndicator
        {
            get;
        }
    }
}
