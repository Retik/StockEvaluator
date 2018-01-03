using System.Collections.Generic;
namespace Avapi.AvapiTRIMA
{
    public interface Int_TRIMA
    {
		IAvapiResponse_TRIMA Query(
			string symbol,
			Const_TRIMA.TRIMA_interval interval,
			int time_period,
			Const_TRIMA.TRIMA_series_type series_type);


		IAvapiResponse_TRIMA Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_TRIMA
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_TRIMA_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_TRIMA_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_TRIMA MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_TRIMA> TechnicalIndicator
        {
            get;
        }
    }
}
