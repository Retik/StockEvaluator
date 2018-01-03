using System.Collections.Generic;
namespace Avapi.AvapiPPO
{
    public interface Int_PPO
    {
		IAvapiResponse_PPO Query(
			string symbol,
			Const_PPO.PPO_interval interval,
			Const_PPO.PPO_series_type series_type,
			int fastperiod = -1,
			int slowperiod = -1,
			Const_PPO.PPO_matype matype = Const_PPO.PPO_matype.none);


		IAvapiResponse_PPO Query(
			string symbol,
			string interval,
			string series_type,
			int fastperiod = -1,
			int slowperiod = -1,
			int matype = -1);
	}

    public interface IAvapiResponse_PPO
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_PPO_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_PPO_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_PPO MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_PPO> TechnicalIndicator
        {
            get;
        }
    }
}
