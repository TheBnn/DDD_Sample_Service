namespace Wbx.Sample.Domain.Repository;

using Models;

public interface IRepository<T, TF>
{
    Task<Guid> Add(T entityParams);
    Task Update(T entityParams);
    Task Delete(Guid id);
    Task<Sample> GetById(Guid id);
    Task<IList<Sample>> GetByParams(TF filterParams);
}
