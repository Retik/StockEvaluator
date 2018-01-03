using System.Collections.Generic;
namespace Avapi.AvapiADXR
{
    public interface Int_ADXR
    {
		IAvapiResponse_ADXR Query(
			string symbol,
			Const_ADXR.ADXR_interval interval,
			int time_period);


		IAvapiResponse_ADXR Query(
			string symbol,
			string interval,
			int time_period);
	}

    public interface IAvapiResponse_ADXR
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_ADXR_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_ADXR_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_ADXR MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_ADXR> TechnicalIndicator
        {
            get;
        }
    }
}
