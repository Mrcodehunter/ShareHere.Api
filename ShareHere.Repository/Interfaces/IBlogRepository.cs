namespace ShareHere.Repository
{
    public interface IBlogRepository<T>
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<T> Add(T blog);
        Task<T> Update(T blog, Guid id);
        Task<bool> Delete(Guid id);
    }
}
