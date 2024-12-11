using System.Data;
using Dapper;

namespace ExerciseTracker.Repository;

public class ExerciseRepository<T> : IRepository<T> where T : class
{
    private readonly IDbConnection _dbConnection;

    public ExerciseRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public T GetById(int id)
    {
        var tableName = typeof(T).Name;
        var query = $"SELECT * FROM {tableName}s WHERE Id = @Id";
        return _dbConnection.QueryFirstOrDefault<T>(query, new { Id = id });
    }

    public IEnumerable<T> GetAll()
    {
        var tableName = typeof(T).Name;
        var query = $"SELECT * FROM {tableName}s";
        return _dbConnection.Query<T>(query);
    }

    public void Add(T entity)
    {
        var tableName = typeof(T).Name;
        var properties = entity.GetType().GetProperties().Where(p => p.Name != "Id");
        var columns = string.Join(", ", properties.Select(p => p.Name));
        var parameters = string.Join(", ", properties.Select(p => "@" + p.Name));

        var query = $"INSERT INTO {tableName}s ({columns}) VALUES ({parameters})";
        _dbConnection.Execute(query, entity);
    }

    public void Update(T entity)
    {
        var tableName = typeof(T).Name;
        var properties = entity.GetType().GetProperties().Where(p => p.Name != "Id");
        var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

        var query = $"UPDATE {tableName}s SET {setClause} WHERE Id = @Id";
        _dbConnection.Execute(query, entity);
    }

    public void Delete(int id)
    {
        var tableName = typeof(T).Name;
        var query = $"DELETE FROM {tableName}s WHERE Id = @Id";
        _dbConnection.Execute(query, new { Id = id });
    }

    private string GetUpdateParameters(T entity)
    {
        return string.Join(", ", entity.GetType().GetProperties().Select(p => $"{p.Name} = @{p.Name}"));
    }
}