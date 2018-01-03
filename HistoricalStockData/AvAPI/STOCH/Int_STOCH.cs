using System.Collections.Generic;
namespace Avapi.AvapiSTOCH
{
    public interface Int_STOCH
    {
		IAvapiResponse_STOCH Query(
			string symbol,
			Const_STOCH.STOCH_interval interval,
			int fastkperiod = -1,
			int slowkperiod = -1,
			int slowdperiod = -1,
			Const_STOCH.STOCH_slowkmatype slowkmatype = Const_STOCH.STOCH_slowkmatype.none,
			Const_STOCH.STOCH_slowdmatype slowdmatype = Const_STOCH.STOCH_slowdmatype.none);


		IAvapiResponse_STOCH Query(
			string symbol,
			string interval,
			int fastkperiod = -1,
			int slowkperiod = -1,
			int slowdperiod = -1,
			int slowkmatype = -1,
			int slowdmatype = -1);
	}

    public interface IAvapiResponse_STOCH
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_STOCH_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_STOCH_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_STOCH MetaData
        {
            get;
        }

        IList <TechnicalIndicator_Type_STOCH> TechnicalIndicator
        {
            get;
        }
    }
}
