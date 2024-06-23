using MyProject.Attributes;
using MyProject.Dapper;
using MyProject.Models;
using Dapper;

namespace MyProject.Repositories;

public class BaseRepository<T> : IRepository, IRepository<T> where T : BaseModel {

    protected readonly DapperContext _context;

    public BaseRepository(DapperContext context) {
        _context = context;

        Type type = GetType();
        Attribute? attribute = Attribute.GetCustomAttribute(type, typeof(ModelNameAttribute));
        if(attribute == null) return;
        ModelNameAttribute modelNameAttribute = (ModelNameAttribute)attribute;

        attribute = Attribute.GetCustomAttribute(type, typeof(ModelNamePluralAttribute));
        ModelNamePluralAttribute? modelNamePluralAttribute = attribute != null ? (ModelNamePluralAttribute)attribute : null;

        EntityName = modelNameAttribute.Name;
        EntityPluralName = modelNamePluralAttribute != null ? modelNamePluralAttribute.PluralName : $"{EntityName}s";
        GetAllStoredProcedure = $"{EntityPluralName}_load";
        GetStoredProcedure = $"{EntityName}_load";
        CreateStoredProcedure = $"{EntityName}_create";
        DeleteStoredProcedure = $"{EntityName}_delete";
        UpdateStoredProcedure = $"{EntityName}_update";
    }

    protected virtual string? EntityName { get; set; }
    protected virtual string? EntityPluralName { get; set; }

    protected virtual string? GetAllStoredProcedure { get; set; }
    protected virtual string? GetStoredProcedure { get; set; }
    protected virtual string? CreateStoredProcedure { get; set; }
    protected virtual string? DeleteStoredProcedure { get; set; }
    protected virtual string? UpdateStoredProcedure { get; set; }

    public async Task<IEnumerable<T>> GetAllAsync() {
        if (string.IsNullOrEmpty(GetAllStoredProcedure)) throw new InvalidOperationException("GetAllStoredProcedure is not set");
        using var db = _context.CreateConnection();
        return await db.QueryStoredProcedureAsync<T>(GetAllStoredProcedure);
    }

    public async Task<T?> GetAsync(int id) {
        if(string.IsNullOrEmpty(GetStoredProcedure)) throw new InvalidOperationException("GetStoredProcedure is not set");
        using var db = _context.CreateConnection();
        var result = await db.QueryStoredProcedureAsync<T>(GetStoredProcedure, new DynamicParameters(new { id }));
        return result.Any() ? result.First() : default;
    }

    public async Task<int> CreateAsync(DynamicParameters parameters) {
        if(string.IsNullOrEmpty(CreateStoredProcedure)) throw new InvalidOperationException("CreateStoredProcedure is not set");
        using var db = _context.CreateConnection();
        return await db.ExecuteStoredProcedureAsync(CreateStoredProcedure, parameters);
    }

    public virtual Task<int> CreateAsync(T entity, int userId, int tenantId) {
        throw new NotImplementedException();
    }

}
