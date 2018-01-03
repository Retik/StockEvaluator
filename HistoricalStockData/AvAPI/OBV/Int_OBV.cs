using System.Collections.Generic;
namespace Avapi.AvapiOBV
{
    public interface Int_OBV
    {
		IAvapiResponse_OBV Query(
			string symbol,
			Const_OBV.OBV_interval interval);


		IAvapiResponse_OBV Query(
			string symbol,
			string interval);
	}

    public interface IAvapiResponse_OBV
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_OBV_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_OBV_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_OBV MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_OBV> TechnicalIndicator
        {
            get;
        }
    }
}
