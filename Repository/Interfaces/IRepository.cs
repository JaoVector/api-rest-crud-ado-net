namespace ADOProject_API.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        IQueryable<T> ConsultaProdutos(int limite);
        T ConsultaPorId(int id);
    }
}
