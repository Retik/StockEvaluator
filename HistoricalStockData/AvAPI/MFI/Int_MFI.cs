using System.Collections.Generic;
namespace Avapi.AvapiMFI
{
    public interface Int_MFI
    {
		IAvapiResponse_MFI Query(
			string symbol,
			Const_MFI.MFI_interval interval,
			int time_period);


		IAvapiResponse_MFI Query(
			string symbol,
			string interval,
			int time_period);
	}

    public interface IAvapiResponse_MFI
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_MFI_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_MFI_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_MFI MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_MFI> TechnicalIndicator
        {
            get;
        }
    }
}
