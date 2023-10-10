using JazaniTaller.Core.Paginations;
namespace JazaniTaller.Domain.Cores.Paginations
{
    public interface IPaginator<T>
    {
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request);
    }
}
