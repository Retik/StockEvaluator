using System.Collections.Generic;
namespace Avapi.AvapiEMA
{
    public interface Int_EMA
    {
		IAvapiResponse_EMA Query(
			string symbol,
			Const_EMA.EMA_interval interval,
			int time_period,
			Const_EMA.EMA_series_type series_type);


		IAvapiResponse_EMA Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_EMA
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_EMA_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_EMA_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_EMA MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_EMA> TechnicalIndicator
        {
            get;
        }
    }
}
