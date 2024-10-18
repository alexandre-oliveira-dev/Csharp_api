
using System;
using System.Data;
using System.Transactions;
using Npgsql;

public static class DataContext
{
    public static IDbConnection CreateConnection()
    {
        string url = "Host=ep-wild-pond-a4n245h5-pooler.us-east-1.aws.neon.tech:5432;Username=default;Password=RtJgPcd78EnC;Database=verceldb";
        return new NpgsqlConnection(url);
    }

    public static void CloseAndDispose(IDbConnection _dbConn)
    {
        if (_dbConn == null)
            return;

        if (_dbConn.State == ConnectionState.Open)
            _dbConn.Close();

        _dbConn.Dispose();
    }

    public static TransactionScope CreateTransactionScope()
    {
        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
            Timeout = TransactionManager.MaximumTimeout
        };

        return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
    }

}

