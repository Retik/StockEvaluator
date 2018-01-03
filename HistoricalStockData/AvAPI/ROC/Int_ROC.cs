using System.Collections.Generic;
namespace Avapi.AvapiROC
{
    public interface Int_ROC
    {
		IAvapiResponse_ROC Query(
			string symbol,
			Const_ROC.ROC_interval interval,
			int time_period,
			Const_ROC.ROC_series_type series_type);


		IAvapiResponse_ROC Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_ROC
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_ROC_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_ROC_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_ROC MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_ROC> TechnicalIndicator
        {
            get;
        }
    }
}
