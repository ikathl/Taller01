using JazaniTaller.Core.Paginations;

namespace JazaniTaller.Domain.Cores.Repositories
{
    public interface IPaginatedRepository<T>
    {
        Task<ResponsePagination<T>> PaginatedSearch(RequestPagination<T> entity);
    }
}
