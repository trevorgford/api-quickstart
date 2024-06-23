namespace MyProject.Repositories;

public interface IRepository {}

public interface IRepository<T> {

    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task<int> CreateAsync(T entity, int userId, int tenantId);

}
