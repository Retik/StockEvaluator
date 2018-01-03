using System.Collections.Generic;
namespace Avapi.AvapiROCR
{
    public interface Int_ROCR
    {
		IAvapiResponse_ROCR Query(
			string symbol,
			Const_ROCR.ROCR_interval interval,
			int time_period,
			Const_ROCR.ROCR_series_type series_type);


		IAvapiResponse_ROCR Query(
			string symbol,
			string interval,
			int time_period,
			string series_type);
	}

    public interface IAvapiResponse_ROCR
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_ROCR_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_ROCR_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_ROCR MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_ROCR> TechnicalIndicator
        {
            get;
        }
    }
}
