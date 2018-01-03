using System.Collections.Generic;
namespace Avapi.AvapiT3
{
    public interface Int_T3
    {
		IAvapiResponse_T3 Query(
			string symbol,
			Const_T3.T3_interval interval,
			int time_period,
			Const_T3.T3_series_type series_type);


		IAvapiResponse_T3 Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_T3
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_T3_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_T3_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_T3 MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_T3> TechnicalIndicator
        {
            get;
        }
    }
}
