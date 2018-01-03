using System.Collections.Generic;
namespace Avapi.AvapiTRANGE
{
    public interface Int_TRANGE
    {
		IAvapiResponse_TRANGE Query(
			string symbol,
			Const_TRANGE.TRANGE_interval interval);


		IAvapiResponse_TRANGE Query(
			string symbol,
			string interval);
	}

    public interface IAvapiResponse_TRANGE
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TRANGE_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TRANGE_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TRANGE MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_TRANGE> TechnicalIndicator
        {
            get;
        }
    }
}
