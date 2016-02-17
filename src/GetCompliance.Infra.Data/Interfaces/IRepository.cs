namespace GetCompliance.Infra.Data.Interfaces
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        void Update(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
