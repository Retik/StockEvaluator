using System.Collections.Generic;
namespace Avapi.AvapiWMA
{
    public interface Int_WMA
    {
		IAvapiResponse_WMA Query(
			string symbol,
			Const_WMA.WMA_interval interval,
			int time_period,
			Const_WMA.WMA_series_type series_type);


		IAvapiResponse_WMA Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_WMA
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_WMA_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_WMA_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_WMA MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_WMA> TechnicalIndicator
        {
            get;
        }
    }
}
