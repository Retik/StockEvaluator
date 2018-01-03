using System.Collections.Generic;
namespace Avapi.AvapiBATCH_STOCK_QUOTES
{
    public interface Int_BATCH_STOCK_QUOTES
    {
		IAvapiResponse_BATCH_STOCK_QUOTES Query(
			string symbols,
			Const_BATCH_STOCK_QUOTES.BATCH_STOCK_QUOTES_datatype datatype = Const_BATCH_STOCK_QUOTES.BATCH_STOCK_QUOTES_datatype.none);


		IAvapiResponse_BATCH_STOCK_QUOTES Query(
			string symbols,
			string datatype = null);
	}

    public interface IAvapiResponse_BATCH_STOCK_QUOTES
    {
        string LastHttpRequest
        {
            get;
        }

        string RawData
        {
            get;
        }

        IAvapiResponse_BATCH_STOCK_QUOTES_Content Data
        {
            get;
        }
    }

    public interface IAvapiResponse_BATCH_STOCK_QUOTES_Content
    {
        bool Error
        {
            get;
        }

        string ErrorMessage
        {
            get;
        }

        MetaData_Type_BATCH_STOCK_QUOTES MetaData
        {
            get;
        }

        IList <StockQuotes_Type_BATCH_STOCK_QUOTES> StockQuotes
        {
            get;
        }
    }
}
