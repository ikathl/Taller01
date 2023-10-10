using JazaniTaller.Core.Paginations;

namespace JazaniTaller.Application.Cores.Services
{
    public interface IPaginatedService<TDto, TDtoFilter>
    {
        Task<ResponsePagination<TDto>> PaginatedSearch(RequestPagination<TDtoFilter> request);
    }
}
