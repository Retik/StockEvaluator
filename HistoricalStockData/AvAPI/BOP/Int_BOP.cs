using System.Collections.Generic;
namespace Avapi.AvapiBOP
{
    public interface Int_BOP
    {
		IAvapiResponse_BOP Query(
			string symbol,
			Const_BOP.BOP_interval interval);


		IAvapiResponse_BOP Query(
			string symbol,
			string interval);
	}

    public interface IAvapiResponse_BOP
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_BOP_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_BOP_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_BOP MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_BOP> TechnicalIndicator
        {
            get;
        }
    }
}
