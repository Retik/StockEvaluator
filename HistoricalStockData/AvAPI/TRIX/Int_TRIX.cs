using System.Collections.Generic;
namespace Avapi.AvapiTRIX
{
    public interface Int_TRIX
    {
		IAvapiResponse_TRIX Query(
			string symbol,
			Const_TRIX.TRIX_interval interval,
			int time_period,
			Const_TRIX.TRIX_series_type series_type);


		IAvapiResponse_TRIX Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_TRIX
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TRIX_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TRIX_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TRIX MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_TRIX> TechnicalIndicator
        {
            get;
        }
    }
}
