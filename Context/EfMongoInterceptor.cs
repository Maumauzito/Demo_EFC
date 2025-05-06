using Demo_EFC.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MongoDB.Driver;
using System.Data.Common;

public class EfMongoInterceptor : DbCommandInterceptor
{
    private readonly IMongoCollection<QueryLog> _logCollection;

    public EfMongoInterceptor()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var database = mongoClient.GetDatabase("fiap");
        _logCollection = database.GetCollection<QueryLog>("EfQueries");
    }

    private void LogQuery(string commandText)
    {
        var log = new QueryLog
        {
            CommandText = commandText
        };
        _logCollection.InsertOne(log);
    }

    public override InterceptionResult<int> NonQueryExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result)
    {
        LogQuery(command.CommandText);
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        LogQuery(command.CommandText);
        return base.ReaderExecuting(command, eventData, result);
    }

    public override InterceptionResult<object> ScalarExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result)
    {
        LogQuery(command.CommandText);
        return base.ScalarExecuting(command, eventData, result);
    }
}
