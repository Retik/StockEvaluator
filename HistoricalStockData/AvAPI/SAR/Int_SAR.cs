using System.Collections.Generic;
namespace Avapi.AvapiSAR
{
    public interface Int_SAR
    {
		IAvapiResponse_SAR Query(
			string symbol,
			Const_SAR.SAR_interval interval,
			float acceleration = -1,
			float maximum = -1);


		IAvapiResponse_SAR Query(
			string symbol,
			string interval,
			float acceleration = -1,
			float maximum = -1);
	}

    public interface IAvapiResponse_SAR
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_SAR_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_SAR_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_SAR MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_SAR> TechnicalIndicator
        {
            get;
        }
    }
}
